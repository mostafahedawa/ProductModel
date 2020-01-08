using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Infrastructure.Context;
using Product.Services.IRepositoriey;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class ProductRepositroy : IProductRepository
    {
        #region Properties

        private readonly ProductDbContext _productDbContext;

        #endregion Properties

        #region Constructor

        public ProductRepositroy(ProductDbContext productDbContext)
        {
            this._productDbContext = productDbContext;
        }

        #endregion Constructor

        #region Methods

        public async Task<IEnumerable<Products>> ListAsync()
        {
            return await _productDbContext.Products.AsNoTracking().Include(p => p.Vendor).Include(p => p.DietaryFlag).ToListAsync();
        }

        public async Task<Products> GetByIdAsync(int Id)
        {
            return await _productDbContext.Products.AsNoTracking().Include(p => p.Vendor).Include(p => p.DietaryFlag).SingleOrDefaultAsync(p => p.ID == Id);
        }

        public async Task<Products> CreateAsync(Products entity)
        {
            var result = await _productDbContext.Products.AddAsync(entity);
            await _productDbContext.SaveChangesAsync();
            return entity;
        }

        public async Task<Products> UpdateAsync(int id, Products entity)
        {
            Products existingProduct =  GetByIdAsync(id).Result;
            if (existingProduct != null)
            {
                _productDbContext.Products.Update(entity);
               await _productDbContext.SaveChangesAsync();
            }
            return entity;
        }

        public async Task<Products> Delete(int id)
        {
            Products existingProduct = GetByIdAsync(id).Result;
            if (existingProduct != null)
            {
                _productDbContext.Products.Remove(existingProduct);
                await _productDbContext.SaveChangesAsync();
            }
            return existingProduct;
        }

        #endregion Methods
    }
}