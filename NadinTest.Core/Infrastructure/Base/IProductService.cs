using NadinTest.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Core.Infrastructure.Base
{
    public interface IProductService
    {
        Task<Product> GetById(Guid id);
        Task<List<Product>> GetAll();
        Task<Product> Add(Product product);
        Task<Product> Update(Product product);
        Task DeleteById(Guid id);
    }
}
