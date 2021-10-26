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
        private Machine_Management_Service _machineInfo = new Machine_Management_Service();
        

        [HttpGet("GetAllMachineTypes")]
        public IActionResult GetAllMachineTypes()
        {
            return Ok(_machineInfo.GetMachineTypes());
        }

        [HttpGet("MachineType/{mType}")]
        public IActionResult GetAssetInfo(string mType)
        {
            var MachineToReturn = _machineInfo.GetMachineToShowAssetInfo(mType);

            if (MachineToReturn == null)
            {
                return NotFound();
            }

            return Ok(MachineToReturn);

        }
    }
}
