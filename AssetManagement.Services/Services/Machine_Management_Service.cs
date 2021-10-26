using AssetManagement.Services.Models;
using System.Collections.Generic;
using System.Linq;

namespace AssetManagement.Services.Services
{
    public class Machine_Management_Service
    {
        readonly IAssetRepo _repo;

        public Machine_Management_Service(IAssetRepo repo)
        {
            _repo = repo;
        }

        // Get all machine types
        public IEnumerable<string> GetMachineTypes()
        {
            return _repo.ReadAssets().Select(x => x.MachineType).ToHashSet();
        }

        // Get AssetInfo by using mType(machine type) as user input
        public IEnumerable<Asset> GetMachineToShowAssetInfo(string mType)
        {
            return _repo.ReadAssets().Where(x => x.MachineType == mType).ToList<Asset>();
        }

    }
}
