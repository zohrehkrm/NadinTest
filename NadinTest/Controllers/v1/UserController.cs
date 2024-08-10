using Microsoft.AspNetCore.Authentication.Twitter;
using Microsoft.AspNetCore.Mvc;
using NadinTest.Core.Infrastructure.Base;
using NadinTest.Core.Infrastructure.Users;
using NadinTest.Core.Models.Users;
using NadinTest.Data;
using NadinTest.Service.Services;

namespace NadinTest.Controllers.v1
{
    [ApiController]
    [Route("[Controller]")]
    public class UserController : ControllerBase 
    {
        private readonly IUserService Service;

        public UserController(IUserService userService)
        {
          Service = userService;
        }



        [HttpPost(Name = "PostUser")]
        public async Task<User> Add(User user)
        {
            return await Service.Add(user);
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

        [HttpDelete(Name = "DeleteProduct")]
        public async Task Delete(Guid id)
        {
            await Service.DeleteById(id);
        }

    
        //[HttpGet(Name = "CreateToken")]
        //public Task<AccessToken> CreateToken(string username, string password, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
        //[HttpGet(Name = "CeckPass")]
        //public Task<User> CheckPasswordByUserNameAsync(string userName, string password, CancellationToken cancellationToken)
        //{
        //    throw new NotImplementedException();
        //}
    }
}
