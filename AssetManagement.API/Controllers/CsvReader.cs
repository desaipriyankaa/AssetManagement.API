using AssetManagement.API.Models;
using System.Collections.Generic;
using System.IO;

namespace AssetManagement.API.Controllers
{
    public class CsvReader
    {
        private string _csvFilePath;
        public List<Asset> AssetsList;


        public CsvReader(string csvFilepath)
        {
            this._csvFilePath = csvFilepath;
        }

        public List<Asset> GetAssetsFromFile()
        {
            AssetsList = new List<Asset>();
            using (StreamReader reader = new StreamReader(_csvFilePath))
            {
                string csvLine;
                while ((csvLine = reader.ReadLine()) != null)
                {
                    Asset asset = ReadAssetsFromCsvLine(csvLine);
                    AssetsList.Add(asset);
                }
            }
            return AssetsList;
        }

        private Asset ReadAssetsFromCsvLine(string csvLine)
        {
            string[] parts = csvLine.Split(',');

            return new Asset() { MachineType = parts[0], AssetName = parts[1], SeriesName = parts[2] };
        }
    }
}

