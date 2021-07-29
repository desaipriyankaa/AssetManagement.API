using System;
using System.Collections.Generic;
using Xunit;
using AssetManagement.API.Models;
using AssetManagement.API.Controllers;
using System.Linq;

namespace AssetsManagement.Tests
{
    public class AssetTest
    {
        [Fact]
        public void GetAsset_ShouldDisplayAssetInfo()
        {
            // Arrange
            string mType = "C300";
            AssetManagementController controller = new AssetManagementController();
            var expected = controller.AssetList.Where(x => x.MachineType == mType).ToList();


            // Act
            var actual = controller.GetAssetInfo(mType);


            // Assert
            Assert.Equal(expected, actual);
        }
    }
}
