using Product.Domain.Entities;
using Product.Services.IRepositoriey;
using Product.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Services
{
    public class ProductService : IProductService
    {
        #region Properties
        private readonly IProductRepository _productRepository;
        #endregion

        #region Constructor
        public ProductService(IProductRepository productRepository)
        {
            this._productRepository = productRepository;
        }
        #endregion

        #region Methods
        public async Task<IEnumerable<Products>> ListAsync()
        {
            return await _productRepository.ListAsync();
        }

        public async Task<Products> UpdateAsync(int id, Products entity)
        {
            return await _productRepository.UpdateAsync(id, entity);
        }

        public async Task<Products> CreateAsync(Products entity)
        {
            return await _productRepository.CreateAsync(entity);
        }

        public Task<Products> Delete(int id)
        {
            return _productRepository.Delete(id);
        }

        public async Task<Products> GetByIdAsync(int Id)
        {
            return await _productRepository.GetByIdAsync(Id);
        }
        #endregion
    }
}
