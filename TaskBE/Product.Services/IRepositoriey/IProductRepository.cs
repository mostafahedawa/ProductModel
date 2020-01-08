using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.IRepositoriey
{
  public interface IProductRepository
    {
        Task<IEnumerable<Products>> ListAsync();
        Task<Products> GetByIdAsync(int Id);
        Task<Products> CreateAsync(Products entity);
        Task<Products> UpdateAsync(int id, Products entity);
        Task<Products> Delete(int id);
    }
}
