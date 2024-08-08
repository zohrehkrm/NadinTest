using Microsoft.AspNetCore.Authentication.Twitter;
using NadinTest.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Core.Infrastructure.Users
{
    public interface IUserService
    {
        /// Creates JWT Token 
        /// </summary>
        /// <param name="username"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<AccessToken> CreateToken(string username, string password, CancellationToken cancellationToken);



        /// <summary>
        /// To Make sure that this user is authenticated
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<User> CheckPasswordByUserNameAsync(string userName, string password, CancellationToken cancellationToken);
    }
}
