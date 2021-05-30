using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Controllers
{
    [ApiController]
    [Route("api/assets")]
    public class AssetManagementController : ControllerBase
    {
        [HttpGet]
        public JsonResult GetAssets()
        {
            return new JsonResult(AssetDataStore.Current.assets);
        }

        [HttpGet("{mType}")]
        public JsonResult GetMachineType(string mType)
        {
            return new JsonResult(AssetDataStore.Current.assets.Where(x => x.MachineType == mType).ToList());
        }

        [HttpGet("{aName}")]
        public JsonResult GetAssetName(string aName)
        {
            return new JsonResult(AssetDataStore.Current.assets.Where(x => x.AssetName == aName).ToList());
        }
    }
}
