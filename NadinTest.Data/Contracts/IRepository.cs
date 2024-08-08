using NadinTest.Core.Models.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Data.Contracts
{
    public interface IRepository
    {
        Product Create(Product product);
        List<Product> GetAll(Product product);
        Product GetById(Product product);
        Product Update(Product product);
        void Delete(Product product);
    }
}
