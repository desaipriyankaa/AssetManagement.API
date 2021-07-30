using AssetManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Services
{
    public interface IAssetInfoRepository
    {
        public IEnumerable<string> GetAssetNames();
        public IEnumerable<Asset> GetAssetsToShowAssetInfo(string aName);
        public IEnumerable<string> GetLatestSeries();
    }
}
