using Microsoft.EntityFrameworkCore;
using Application.Interfaces.Context;
using System.ComponentModel.DataAnnotations;
using ToDo.Common;

namespace Application.Services.Authentication
{
    public interface IUserLoginService
    {
        ResultDto<ResultUserloginDto> Execute(string Username, string Password);
    }

    public class UserLoginService : IUserLoginService
    {
        private readonly IToDoContext _context;
        public UserLoginService(IToDoContext context)
        {
            _context = context;
        }
        public ResultDto<ResultUserloginDto> Execute(string Username, string Password)
        {

            if (string.IsNullOrWhiteSpace(Username) || string.IsNullOrWhiteSpace(Password))
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "نام کاربری و رمز عبور را وارد نمایید",
                };
            }



            var User = _context.Users
                .Where(p => p.UserName.Equals(Username))
                .Include(p=>p.Role)
                .FirstOrDefault();

            if (User == null)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "نام کاربری یافت نشد",
                };
            }

            
            
            if (User.Password != Password)
            {
                return new ResultDto<ResultUserloginDto>()
                {
                    Data = new ResultUserloginDto()
                    {

                    },
                    IsSuccess = false,
                    Message = "رمز وارد شده اشتباه است!",
                };
            }


            string Role = User.Role.Title;
            
            return new ResultDto<ResultUserloginDto>()
            {
                Data = new ResultUserloginDto()
                {
                    Role = Role,
                    UserID = User.UserId,
                    Name = User.FirstName + " " + User.LastName
                },
                IsSuccess = true,
                Message = "ورود با موفقیت انجام شد",
            };


        }
    }

    public class ResultUserloginDto
    {
        public int UserID { get; set; }
        public string Role { get; set; }
        public string Name { get; set; }
    }

    public class RequestloginDto
    {
        [Required(ErrorMessage = "لطفا نام کاربری را وارد کنید.")]
        public string UserName { get; set; }

        [Required(ErrorMessage = "لطفا گذرواژه را وارد کنید.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "لطفا حاصل جمع تصویر را بنویسید.")]
        public string Captcha { get; set; }
    }

}
