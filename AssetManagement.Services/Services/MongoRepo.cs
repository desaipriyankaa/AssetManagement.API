using AssetManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Services.Services
{
    public class MongoRepo : IAssetRepo
    {
        public List<Asset> CreateAsset(string mType, string aName, string sName)
        {
            throw new NotImplementedException();
        }

        public List<Asset> ReadAssets()
        {
            throw new NotImplementedException();
        }
    }
}
