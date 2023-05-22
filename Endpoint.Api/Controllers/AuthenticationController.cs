using Application.Services.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Identity;
using ToDo.Common;

namespace Endpoint.Api.Controllers
{
    public class AuthenticationController : Controller
    {
        
        private readonly IUserLoginService _userLoginService;

        public AuthenticationController(IUserLoginService userLoginService)
        {
            _userLoginService = userLoginService;
        }

        [HttpPost]
        public IActionResult Signin([Bind("UserName,Password,Captcha")] RequestloginDto request)
        {
            try
            {
                var signinResult = _userLoginService.Execute(request.UserName, request.Password);
                if (signinResult.IsSuccess == true)
                {
                    var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,signinResult.Data.UserID.ToString()),
                    new Claim(ClaimTypes.Name, signinResult.Data.Name),
                    new Claim(ClaimTypes.Role, signinResult.Data.Role),
                };
                    var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                    var principal = new ClaimsPrincipal(identity);
                    var properties = new AuthenticationProperties()
                    {
                        IsPersistent = true,
                        ExpiresUtc = DateTime.Now.AddDays(5),
                    };
                    HttpContext.SignInAsync(principal, properties);
                    return Json(signinResult);
                }
                else
                {
                    return Json(signinResult);
                }

            }
            catch (Exception e)
            {
                return Json(new ResultDto<ResultUserloginDto>()
                {
                    Message = e.Message,
                    IsSuccess = false,
                    Data = null,
                });
            }
            
            
        }

        public IActionResult SignOut()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return Json(new ResultDto()
            {
                Message = "Sign out Successfully",
                IsSuccess = false,
            });
        }

    }
}
