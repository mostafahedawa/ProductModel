using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.IRepositoriey
{
   public interface ILookupRepository
    {
        Task<IEnumerable<Vendor>> VendorAListsyncAsync();
        Task<IEnumerable<DietaryFlags>> FlagListAsync();
    }
}
