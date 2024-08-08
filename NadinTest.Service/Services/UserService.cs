using Microsoft.AspNetCore.Authentication.Twitter;
using NadinTest.Core.Infrastructure.Users;
using NadinTest.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Service.Services
{
    public class UserService : IUserService
    {
        public Task<User> CheckPasswordByUserNameAsync(string userName, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }

        public Task<AccessToken> CreateToken(string username, string password, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
