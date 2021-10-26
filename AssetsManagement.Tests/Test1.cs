using AssetManagement.API.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace AssetsManagement.Tests
{
    public class Test1
    {
        [Fact]
        public void RetrivesMachineInfo()
        {
            AssetController assetController = new AssetController();
            var Actual = assetController.getLatestSeries();
            string Expected = "C60";
            Assert.Equal(Expected, Actual.ToString());
        }
    }
}
