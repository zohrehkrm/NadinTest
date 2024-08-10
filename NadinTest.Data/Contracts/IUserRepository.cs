using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Data.Contracts
{
    public interface IUserRepository
    {
        Task<User> Create(User user);
        Task<List<User>> GetAll();
        Task<User> GetById(Guid Id);
        Task<User> Update(User user);
        Task Delete(User user);
    }
}
