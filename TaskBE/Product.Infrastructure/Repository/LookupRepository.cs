using Microsoft.EntityFrameworkCore;
using Product.Domain.Entities;
using Product.Infrastructure.Context;
using Product.Services.IRepositoriey;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Infrastructure.Repository
{
    public class LookupRepository : ILookupRepository
    {
        #region Properties

        private readonly ProductDbContext _productDbContext;

        #endregion Properties

        #region Constructor

        public LookupRepository(ProductDbContext productDbContext)
        {
            this._productDbContext = productDbContext;
        }

        #endregion Constructor
        public async Task<IEnumerable<DietaryFlags>> FlagListAsync()
        {
            return await _productDbContext.DietaryFlags.AsNoTracking().ToListAsync();
        }

        public async Task<IEnumerable<Vendor>> VendorAListsyncAsync()
        {
            return await _productDbContext.Vendor.AsNoTracking().ToListAsync();
        }
    }
}
