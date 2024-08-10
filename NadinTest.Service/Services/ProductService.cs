using Microsoft.EntityFrameworkCore;
using NadinTest.Core.Infrastructure.Base;
using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using NadinTest.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;


namespace NadinTest.Service.Services
{
    public class ProductService : IProductService
    {
        private readonly IRepository repository;
        public ProductService(IRepository repository)
        {
            this.repository = repository;
        }


        public async Task<Product> Add(Product product)
        {
            var res = await repository.Create(product);
            if (res == null)
                return null;
            return res;
        }

     
        public async Task DeleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Product>> GetAll()
        {
            var user = await repository.GetAll();
            if (user == null)
                return null;
            return user;
        }

        public async Task<Product> GetById(Guid id)
        {
            var user = await repository.GetById(id);
            if (user == null)
                return null;
            return user;
        }

        public async Task<Product> Update(Product product)
        {
            var user = await repository.Update(product);
            if (user == null)
                return null;
            return user;
        }

        
    }
}
