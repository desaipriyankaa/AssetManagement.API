using Start.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AssetManagement.API
{
    public class AssetDataStore
    {
        internal static AssetDataStore Current { get; } = new AssetDataStore();

        public List<Asset> assets { get; set; }

        public AssetDataStore()
        {
            assets = new List<Asset>
            {
                new Asset()
                {
                    MachineType="C300",
                    AssetName="Cutter head",
                    SeriesName="S6"
                },

                new Asset()
                {
                    MachineType="C40",
                    AssetName="Cutter head",
                    SeriesName="S7"
                },

                new Asset()
                {
                    MachineType="C300",
                    AssetName="Blade safety cover",
                    SeriesName="S10"
                },

                new Asset()
                {
                    MachineType="C60",
                    AssetName="Blade safety cover",
                    SeriesName="S11"
                },

                new Asset()
                {
                    MachineType="C300",
                    AssetName="Deburring blades",
                    SeriesName="S6"
                },

                new Asset()
                {
                    MachineType="C60",
                    AssetName="Cutter head",
                    SeriesName="S8"
                },

                new Asset()
                {
                    MachineType="C60",
                    AssetName="Clamping fixture",
                    SeriesName="S2"
                },

                new Asset()
                {
                    MachineType="C40",
                    AssetName="Blade safety cover",
                    SeriesName="S11"
                },

                new Asset()
                {
                    MachineType="C40",
                    AssetName="Shutter gripper",
                    SeriesName="S3"
                },

            };
        }
    }
}
