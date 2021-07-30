using System;
using System.Collections.Generic;
using Xunit;
using AssetManagement.API.Models;
using AssetManagement.API.Controllers;
using System.Linq;
using AssetManagement.API.Services;

namespace AssetsManagement.Tests
{
    public class AssetTest
    {
        [Fact]
        public void GetAsset_ShouldDisplayAssetInfo()
        {
            // Arrange
            string mType = "C300";
            var assetInfo = new AssetInfo();
            var Csv = new CsvReader();

            var expected = Csv.AssetsList;


            // Act
            var actual = assetInfo.GetAssetNames();


            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
