using Microsoft.AspNetCore.Mvc;
using AssetManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.API.Services;

namespace AssetManagement.API.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetController : ControllerBase
    {

        private Asset_Management_Service _assetInfo = new Asset_Management_Service();

        

        [HttpGet("GetAllAssetNames")]
        public IActionResult GetAllAssetNames()
        {
            return Ok(_assetInfo.GetAssetNames());
        }


        [HttpGet("AssetName/{aName}")]
        public IActionResult GetMachineInfo(string aName)
        {
            var AssetToReturn = _assetInfo.GetAssetsToShowAssetInfo(aName);
            
            if (AssetToReturn == null)
            {
                return NotFound();
            }

            return Ok(AssetToReturn);

        }


        [HttpGet("LatestSeries")]
        public IActionResult getLatestSeries()
        {
            var result = _assetInfo.GetLatestSeries();
           
            return Ok(result.ToHashSet());
        }

    }
}
