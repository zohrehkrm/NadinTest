using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Data.Contracts
{
    public interface IRepository
    {
         Task<Product> Create(Product product);
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid Id);
        Task Delete(Product product);
        Task<Product> Update(Product product);
    }
}
