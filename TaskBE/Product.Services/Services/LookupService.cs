using Product.Domain.Entities;
using Product.Services.IRepositoriey;
using Product.Services.IServices;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Product.Services.Services
{
    public class LookupService : ILookupService
    {
        #region Properties
        private readonly ILookupRepository _lookupRepository;
        #endregion

        #region Constructor
        public LookupService(ILookupRepository lookupRepository)
        {
            _lookupRepository = lookupRepository;
        }
        #endregion

        public Task<IEnumerable<DietaryFlags>> FlagListAsync()
        {
            return _lookupRepository.FlagListAsync();
        }

        public Task<IEnumerable<Vendor>> VendorAListsync()
        {
            return _lookupRepository.VendorAListsyncAsync();
        }
    }
}
