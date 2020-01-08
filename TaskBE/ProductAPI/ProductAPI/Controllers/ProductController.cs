using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Product.Domain.Entities;
using Product.Services.IServices;

namespace Product.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        #region Properties
        private readonly IProductService _productService;
        #endregion

        #region Constructor
        public ProductController(IProductService productService)
        {
            _productService = productService;
        }
        #endregion

        #region Methods
        // GET: api/Product
        [HttpGet]
        public  Task<IEnumerable<Products>> GetAsync()
        {
            return  _productService.ListAsync();
        }

        // GET: api/Product/5
        [HttpGet("{id}", Name = "Get")]
        public Task<Products> Get(int id)
        {
            return _productService.GetByIdAsync(id);
        }

        // POST: api/Product
        [HttpPost]
        public Task<Products> Post([FromBody] Products entity)
        {
            return _productService.CreateAsync(entity);
        }

        // PUT: api/Product/5
        [HttpPut("{id}")]
        public Task<Products> Put(int id, [FromBody] Products entity)
        {
            return _productService.UpdateAsync(id,entity);
        }

        // DELETE: api/ApiWithActions/5
        [HttpDelete("{id}")]
        public Task<Products> Delete(int id)
        {
            return _productService.Delete(id);
        }
        #endregion
    }
}
