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
    public class LookupsController : ControllerBase
    {
        #region Properties
        private readonly ILookupService _lookupService;
        #endregion

        #region Constructor
        public LookupsController(ILookupService lookupService)
        {
            _lookupService = lookupService;
        }
        #endregion

        #region Methods
        // GET: api/lookup/GetAllVendors
        [HttpGet("GetAllVendors")]
        public Task<IEnumerable<Vendor>> GetAllVendors()
        {
            return _lookupService.VendorAListsync();
        }
        // GET: api/lookup/GetAllFlags
        [HttpGet("GetAllFlags")]
        public Task<IEnumerable<DietaryFlags>> GetAllFlags()
        {
            return _lookupService.FlagListAsync();
        }
        #endregion

    }
}