using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NadinTest.Core.Infrastructure.Users;
using NadinTest.Core.JWT;
using NadinTest.Core.Models.Users;
using NadinTest.Data.Contracts;


namespace NadinTest.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;
        private readonly IJwtService jwtService;
  

        public UserService(IUserRepository repository, IJwtService jwtService)
        {

            this.repository = repository;
            this.jwtService = jwtService;
        }

        public async Task<User> Add(User user)
        {
            var res = await repository.Create(user);
            if (res == null)
                return null;
            return res;
        }

        public async Task<List<User>> GetAll()
        {
            var res = await repository.GetAll();
            if (res == null)
                return null;
            return res;
        }

        public async Task<User> GetById(Guid id)
        {
            var res = await repository.GetById(id);
            if (res == null)
                return null;
            return res;
        }

        public async Task<User> Update(User user)
        {
            var res = await repository.Update(user);
            if (res == null)
                return null;
            return res;
        }


        public async Task<User> CheckPasswordByUserNameAsync(string userName, string password, CancellationToken cancellationToken)
        {
            var user = await this.FindByNameAsync(userName, cancellationToken);
            if (user is null)
                throw new Exception( "نام کاربری یا رمز عبور اشتباه است");

            var isPasswordValid = await repository.CheckPasswordAsync(user, password);
            if (!isPasswordValid)
                throw new Exception("نام کاربری یا رمز عبور اشتباه است");

            return user;
        }


        public async Task<AccessToken> CreateToken(string userName, string password, CancellationToken cancellationToken)
        {
            var user = await this.CheckPasswordByUserNameAsync(userName, password, cancellationToken);
            return await jwtService.GenerateAsync(user);
          
        }
        public async Task<User> FindByNameAsync(string userName, CancellationToken cancellationToken)
        {

            var user = await repository.FindByUserName(userName);
            return user;
        }




        public async Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }
               
    }
}
