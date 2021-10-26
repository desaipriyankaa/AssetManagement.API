using System.Collections.Generic;
using System.Linq;
using AssetManagement.Services.Models;

namespace AssetManagement.Services.Services
{
    public class Asset_Management_Service
    {
        readonly IAssetRepo _repo;
               
        public Asset_Management_Service(IAssetRepo repo)
        {
            _repo = repo;
        }

        public IEnumerable<string> GetAssetNames()
        {
            return _repo.ReadAssets().Select(x => x.AssetName).ToHashSet();
        }

        // Get Asset Info by taking asset input from user
        public IEnumerable<Asset> GetAssetsToShowAssetInfo(string aName)
        {
            return _repo.ReadAssets().Where(x => x.AssetName == aName).ToList<Asset>();
        }

        public IEnumerable<string> GetLatestSeries()
        {
            var result = new List<string>();
            // Find out all latest asset

            var newSeries = _repo.ReadAssets().OrderByDescending(x => x.SeriesName).
                ThenBy(x => x.AssetName).
                GroupBy(x => x.AssetName).
                Select(g => g.First()).ToList();


            // remaining old series

            var remain_old_assets = _repo.ReadAssets().Except(newSeries).ToList();



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
            return (result.ToHashSet());
        }
    }
}
