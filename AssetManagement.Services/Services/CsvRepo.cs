using AssetManagement.Services.Models;
using AssetManagement.Services.Services;
using System.Collections.Generic;
using System.IO;

namespace AssetManagement.Services.Services
{
    public class CsvRepo : IAssetRepo
    {
        string _filePath = @"D:\Projects\Asset\AssetManagement.Services\Data\Matrix.txt";
        public List<Asset> AssetsList;


        public List<Asset> ReadAssets()
        {
            AssetsList = new List<Asset>();
            using (StreamReader reader = new StreamReader(_filePath))
            {
                string csvLine;
                while ((csvLine = reader.ReadLine()) != null)
                {
                    string[] parts = csvLine.Split(',');

                    Asset asset = new Asset() { MachineType = parts[0], AssetName = parts[1], SeriesName = parts[2] };
                    AssetsList.Add(asset);
                }
            }
            return AssetsList;
        }

        public List<Asset> CreateAsset(string machineType, string assetName,string seriesName)
        {
            AssetsList = new List<Asset>();
            using (StreamWriter writer = new StreamWriter(_filePath,true))
            {
                    Asset asset = new Asset() {MachineType=machineType,AssetName=assetName,SeriesName=seriesName};
                AssetsList.Add(asset);
                string str = $"{asset.MachineType},{asset.AssetName},{asset.SeriesName}";
                writer.WriteLine(str);
                writer.Close();
            }
            return AssetsList;
        }
    }
}

