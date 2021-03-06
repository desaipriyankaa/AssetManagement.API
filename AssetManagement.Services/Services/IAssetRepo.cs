using AssetManagement.Services.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AssetManagement.Services.Services
{
    public interface IAssetRepo
    {
        public List<Asset> ReadAssets();
        public List<Asset> CreateAsset(string mType, string aName, string sName);
    }
}
