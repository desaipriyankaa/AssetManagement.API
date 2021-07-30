using AssetManagement.API.Controllers;
using AssetManagement.API.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API.Services
{
    public class MachineInfo : IMachineInfoRepository
    {
        string filepath = @"F:\PProject\API\AssetManagement\AssetManagement.API\Controllers\Matrix.txt";

        CsvReader reader;
        
        public List<Asset> AssetList { get; set; }

        public MachineInfo()
        {
            reader = new CsvReader(filepath);
            AssetList = reader.GetAssetsFromFile();
        }

        // Get all machine types
        public IEnumerable<string> GetMachineTypes()
        {
            return AssetList.Select(x => x.MachineType).ToHashSet();
        }

        // Get AssetInfo by using mType(machine type) as user input
        public IEnumerable<Asset> GetMachineToShowAssetInfo(string mType)
        {
            return AssetList.Where(x => x.MachineType == mType).ToList<Asset>();
        }

    }
}
 