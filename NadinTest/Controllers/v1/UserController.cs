using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NadinTest.Core.Infrastructure.Base;
using NadinTest.Core.Infrastructure.Users;
using NadinTest.Core.Models.Users;
using NadinTest.Data;
using NadinTest.Models.Jwt;
using NadinTest.Service.Services;

namespace NadinTest.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase 
    {
        private readonly IUserService Service;
        private readonly UserManager<User> userManager ;
        private readonly SignInManager<User> SignInManager;

        public UserController(IUserService userService, SignInManager<User> SignInManager, UserManager<User> userManager)
        {
            Service = userService;
            this.userManager = userManager;
            this.SignInManager = SignInManager;

        }


        [AllowAnonymous]
        [HttpPost(Name = "PostUser")]
        public async Task<User> Add(User user)
        {
           
            return await Service.Add(user);
        }

        public async Task<IActionResult> login(User user)
        {

            var _user = userManager.FindByNameAsync(user.UserName);
            try
            {
                if (_user == null)
                {
                    var signInRes = await SignInManager.PasswordSignInAsync(user.UserName, user.PassWord, false, false);
                    if (signInRes.Succeeded)
                    {
                        return RedirectToAction("Index", "Home");
                    }
                    else
                    {
                         return  this.RedirectToAction("Index", "Home");    
                    }
                }

            }
            catch (Exception ex) {
                return this.RedirectToAction("Index", "Home");
            }

            return this.RedirectToAction("Index", "Home");
        }



        [HttpGet(Name = "GetUser")]
        public async Task<List<User>> GetAll()
        {
            return await Service.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<User> GetById(Guid id)
        {
            return await Service.GetById(id);
        }
        [HttpPut(Name = "PutUser")]
        public async Task<User> Update(User user)
        {
            return await Service.Update(user);
        }

        [HttpDelete(Name = "DeleteUser")]
        public async Task Delete(Guid id)
        {
            await Service.DeleteById(id);
        }




        [AllowAnonymous]
        [HttpPost("Token")]
        public virtual async Task<ActionResult> Token( int Token, [FromForm] TokenRequest tokenRequest, CancellationToken cancellationToken)
        {

            var accessToken = await Service.CreateToken(tokenRequest.username, tokenRequest.password, cancellationToken);

            return new JsonResult(accessToken);
        }


    }
}
