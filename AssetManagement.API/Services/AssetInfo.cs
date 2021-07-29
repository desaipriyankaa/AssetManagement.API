using AssetManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Services
{
    public class AssetInfo : IAssetInfoRepository
    {
        public List<Asset> AssetList { get; set; }
        public IEnumerable<Asset> GetAssetsToShowAssetInfo(string aName)
        {
           return AssetList.Where(x => x.AssetName == aName).ToList<Asset>();
        }
    }
}
