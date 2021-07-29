using AssetManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Services
{
    public interface IMachineInfoRepository
    {
        public IEnumerable<string> GetMachineTypes();
        public IEnumerable<Asset> GetMachineToShowAssetInfo(string mType);
    }
}
