using Microsoft.AspNetCore.Authentication.Twitter;
using NadinTest.Core.Infrastructure.Users;
using NadinTest.Core.Models.Users;
using NadinTest.Data.Contracts;


namespace NadinTest.Service.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository repository;

        public UserService(IUserRepository repository)
        {

            this.repository = repository;
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
            throw new NotImplementedException();
        }

        public async Task<AccessToken> CreateToken(string username, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }




        public async Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
