using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MaiHau.Identity.Data.Models;
using MaiHau.Identity.ViewModels;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MaiHau.Identity.Controllers
{
    [Route("api/[controller]")]
    public class AccountController : Controller
    {
        UserManager<User> userManager;
        public AccountController(UserManager<User> userManager)
        {
            this.userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> Register([FromBody]RegisterViewModel model)
        {
            var user = new User() { Email = model.Email, UserName = model.Email };

            var result = await this.userManager.CreateAsync(user, model.Password);

            if (result.Succeeded)
                return this.OkResult();
            else
            {
                if(result.Errors.Any(m => m.Code == "DuplicateUserName"))
                {
                    return this.ErrorResult(ErrorCode.REGISTER_DUPLICATE_USER_NAME);
                }
                return this.ErrorResult(ErrorCode.BAD_REQUEST);
            }
        }
    }
}
