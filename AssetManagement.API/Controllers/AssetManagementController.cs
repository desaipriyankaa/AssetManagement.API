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
    public class AssetManagementController : ControllerBase
    {
        string filepath = @"F:\PProject\API\AssetManagement\AssetManagement.API\Controllers\Matrix.txt";

        CsvReader reader;
        private readonly IMachineInfoRepository _machineInfoRepository;
        private readonly IAssetInfoRepository _assetInfoRepository;
        public List<Asset> AssetList { get; set; }

        public AssetManagementController(IMachineInfoRepository machineInfoRepository)
        {
            reader = new CsvReader(filepath);
            AssetList = reader.GetAssetsFromFile();
            _machineInfoRepository = machineInfoRepository ??
                throw new ArgumentNullException(nameof(machineInfoRepository)); 
        }


        public AssetManagementController(IAssetInfoRepository assetInfoRepository)
        {
            _assetInfoRepository = assetInfoRepository ??
                throw new ArgumentNullException(nameof(assetInfoRepository));
        }

       
        [HttpGet]
        public IActionResult GetAssets()
        {
            return Ok(AssetList);
        }
        
        [HttpGet("MachineType/{mType}")]
        public IActionResult GetAssetInfo (string mType)
        {
            var MachineToReturn = _machineInfoRepository.GetMachineToShowAssetInfo(mType);

            if (MachineToReturn == null)
            {
                return NotFound();
            }

            return Ok(MachineToReturn);
           
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
            var result = new List<string>();
            // Find out all latest asset

            var newSeries = AssetList.OrderByDescending(x => x.SeriesName).
                ThenBy(x => x.AssetName).
                GroupBy(x => x.AssetName).
                Select(g => g.First()).ToList();


            // remaining old series

            var remain_old_assets = AssetList.Except(newSeries).ToList();



            // compare between newSeries and remain_old_assets, if in old asset we found seies name 
            // that series name we'll exclude and we'll get asset that is using all latest series

            var remain_old_assets_MachineType = remain_old_assets.Select(a => a.MachineType).ToList();
            var newSeies_MachineType = newSeries.Select(a => a.MachineType).ToList();

            foreach (var item in newSeies_MachineType)
            {
                if (remain_old_assets_MachineType.Contains(item))
                {
                    continue;
                }

                result.Add(item);
            }
            return Ok(result.ToHashSet());
        }
    
    }
}
