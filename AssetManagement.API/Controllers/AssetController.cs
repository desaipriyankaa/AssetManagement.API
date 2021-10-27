using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AssetManagement.Services.Services;

namespace AssetManagement.API.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetController : ControllerBase
    {
        IAssetRepo repo = new CsvRepo();

        Asset_Management_Service _assetInfo;

        // Constructor
        public AssetController()
        {
            _assetInfo = new Asset_Management_Service(repo);
        }

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

        [HttpPost("Create Asset/{MachineType},{AssetName},{SeriesNumber}")]
        public IActionResult AddAssetData(string MachineType , string AssetName, string SeriesNumber)
        {
             return Ok( _assetInfo.AddAsset(MachineType, AssetName, SeriesNumber));
        }

        [HttpGet("LatestSeries")]
        public IActionResult getLatestSeries()
        {
            var result = _assetInfo.GetLatestSeries();
           
            return Ok(result.ToHashSet());
        }

    }
}
