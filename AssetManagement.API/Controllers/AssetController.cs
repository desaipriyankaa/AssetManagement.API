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
        
        private readonly IAssetInfoRepository _assetInfoRepository;

        
        public AssetController(IAssetInfoRepository assetInfoRepository)
        {
            _assetInfoRepository = assetInfoRepository ??
                throw new ArgumentNullException(nameof(assetInfoRepository));
        }


        [HttpGet("GetAllAssetNames")]
        public IActionResult GetAllAssetNames()
        {
            return Ok(_assetInfoRepository.GetAssetNames());
        }


        [HttpGet("AssetName/{aName}")]
        public IActionResult GetMachineInfo(string aName)
        {
            var AssetToReturn = _assetInfoRepository.GetAssetsToShowAssetInfo(aName);
            
            if (AssetToReturn == null)
            {
                return NotFound();
            }

            return Ok(AssetToReturn);

        }


        [HttpGet("LatestSeries")]
        public IActionResult getLatestSeries()
        {
            var result = _assetInfoRepository.GetLatestSeries();
           
            return Ok(result.ToHashSet());
        }

    }
}
