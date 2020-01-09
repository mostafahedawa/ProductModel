using Product.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.IServices
{
   public interface ILookupService
    {
        Task<IEnumerable<Vendor>> VendorAListsync();
        Task<IEnumerable<DietaryFlags>> FlagListAsync();
    }
}
