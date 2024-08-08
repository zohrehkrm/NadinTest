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
        Product GetById(Guid id);
        List<Product> GetAll();
        Guid Add(Product product);
        Product Update(Guid Id);
    }
}
