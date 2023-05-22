using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace ToDo.Application.Utilities
{
    public static class ClaimUtility
    {
        public static int GetEmployeeId(ClaimsPrincipal User)
        {
            try
            {
                var claimsIdentity = User.Identity as ClaimsIdentity;

                if (claimsIdentity.FindFirst(ClaimTypes.NameIdentifier) != null)
                {
                    int userId = int.Parse(claimsIdentity.FindFirst(ClaimTypes.NameIdentifier).Value);
                    return userId;
                }
                else
                {
                    return 0;
                }

            }
            catch (Exception ex)
            {

                return 0;
            }

        }
    }
}
