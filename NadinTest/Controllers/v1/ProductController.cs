using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NadinTest.Controllers.BaseApi;
using NadinTest.Core.Infrastructure.Base;
using NadinTest.Core.Models.Base;
using NadinTest.Core.Models.Users;
using NadinTest.Service.Services;
using System.Runtime.CompilerServices;

namespace NadinTest.Controllers.v1
{
    [Authorize]
    [ApiController]
    [Route("[Controller]")]
    public class ProductController : ControllerBase
    {
        protected readonly IProductService Service;
        public ProductController(IProductService Service)
        {
            this.Service = Service;

        }

      
        [HttpPost(Name = "PostProduct")]
        public async Task<Product> Add(Product product)
        {
            
            return await Service.Add(product);
        }

        [AllowAnonymous]
        [HttpGet(Name = "GetProduct")]
        public async Task<List<Product>> GetAll()
        {
            return await Service.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Product> GetById(Guid id)
        {
            return await Service.GetById(id);
        }

        [HttpPut(Name = "PutProduct")]
        public async Task<Product> Update(Product product)
        {
            return await Service.Update(product);
        }

        [HttpDelete(Name = "DeleteProduct")]
        public async Task Delete(Guid id)
        {
            await Service.DeleteById(id);
        }
    }
}
