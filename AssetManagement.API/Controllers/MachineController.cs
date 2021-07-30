using AssetManagement.API.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Controllers
{
    public class MachineController : Controller
    {
        private readonly IMachineInfoRepository _machineInfoRepository;
        public MachineController(IMachineInfoRepository machineInfoRepository)
        {
            _machineInfoRepository = machineInfoRepository ??
                throw new ArgumentNullException(nameof(machineInfoRepository));
        }
        [HttpGet("GetAllMachineTypes")]
        public IActionResult GetAllMachineTypes()
        {
            return Ok(_machineInfoRepository.GetMachineTypes());
        }

        [HttpGet("MachineType/{mType}")]
        public IActionResult GetAssetInfo(string mType)
        {
            var MachineToReturn = _machineInfoRepository.GetMachineToShowAssetInfo(mType);

            if (MachineToReturn == null)
            {
                return NotFound();
            }

            return Ok(MachineToReturn);

        }
    }
}
