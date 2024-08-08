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
        User Create(User product);
        List<User> GetAll(User product);
        User GetById(User product);
        User Update(User product);
        void Delete(User product);
    }
}
