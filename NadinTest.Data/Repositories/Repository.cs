using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using NadinTest.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NadinTest.Data.Repositories
{
    public class Repository : IRepository
    {
        protected readonly ApplicationDbContext DbContext;
        public Repository(ApplicationDbContext dbContext)
        {
            DbContext = dbContext;

        }

        public async Task<Product> Create(Product product)
        {
            DbContext.Products.Add(product);
            DbContext.SaveChanges();
            return product;
        
        }

        public async Task Delete(Product product)
        {

            var res = await GetById(product.Id);
            DbContext.Products.Remove(res);
            DbContext.SaveChanges();

        }

        public async Task<List<Product>> GetAll()
        {
            return DbContext.Products
                 .Select(x => new Product
                 {
                     Id = x.Id,
                     Name = x.Name, 
                     ProduceDate = x.ProduceDate,
                     ManufacturePhone = x.ManufacturePhone,
                     ManufactureEmail = x.ManufactureEmail,
                     IsAvailable = x.IsAvailable
                                   })
                .ToList();
        }

        public async Task<Product> GetById(Guid Id)
        {
            var res = DbContext.Products.FirstOrDefault(x => x.Id == Id);
            if (res == null)
            {
                throw new Exception("کالای مورد نظر یافت نشد.");
            }
            return res;
        }

     
    
        public async Task<Product> Update(Product product)
        {
            var res = await GetById(product.Id);
            DbContext.Products.Update(res);
            DbContext.SaveChanges();
            return res;
          
        }

     }
  

    
}
