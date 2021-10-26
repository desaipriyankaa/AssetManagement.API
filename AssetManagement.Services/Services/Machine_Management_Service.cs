using AssetManagement.API.Controllers;
using AssetManagement.API.Models;
using System.Collections.Generic;
using System.Linq;

namespace AssetManagement.API.Services
{
    public class Machine_Management_Service
    {
        string filepath = @"D:\Projects\Asset\AssetManagement.Services\Data\Matrix.txt";

        CsvReader reader;
        
        public List<Asset> AssetList { get; set; }

        public Machine_Management_Service()
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
 