using AssetManagement.API.Models;
using System.Collections.Generic;
using System.Linq;
using AssetManagement.API.Controllers;

namespace AssetManagement.API.Services
{
    public class Asset_Management_Service
    {
        string filepath = @"D:\Projects\Asset\AssetManagement.Services\Data\Matrix.txt";

        CsvReader reader;

        public List<Asset> AssetList { get; set; }

        public Asset_Management_Service()
        {
            reader = new CsvReader(filepath);
            AssetList = reader.GetAssetsFromFile();
        }

        public IEnumerable<string> GetAssetNames()
        {
            return AssetList.Select(x => x.AssetName).ToHashSet();
        }

        // Get Asset Info by taking asset input from user
        public IEnumerable<Asset> GetAssetsToShowAssetInfo(string aName)
        {
           return AssetList.Where(x => x.AssetName == aName).ToList<Asset>();
        }

        public IEnumerable<string> GetLatestSeries()
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
            return (result.ToHashSet());
        }
    }
}
