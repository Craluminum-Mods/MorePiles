using Vintagestory.API.Common;

namespace MorePiles.Configuration
{
    static class ModConfig
    {
        private const string jsonConfig = "MorePilesConfig.json";
        private static MorePilesConfig config;

        public static void ReadConfig(ICoreAPI api)
        {
            try
            {
                config = LoadConfig(api);

                if (config == null)
                {
                    GenerateConfig(api);
                    config = LoadConfig(api);
                }
                else
                {
                    GenerateConfig(api, config);
                }
            }
            catch
            {
                GenerateConfig(api);
                config = LoadConfig(api);
            }

            foreach (var key in config.Piles.Keys)
            {
                api.World.Config.SetBool($"morepiles-{key}-enabled", config.Piles[key].Enabled);
                api.World.Config.SetBool($"morepiles-{key}-upsolid", config.Piles[key].UpSolid);
                api.World.Config.SetInt($"morepiles-{key}-bulktransferquantity", config.Piles[key].BulkTransferQuantity);
                api.World.Config.SetInt($"morepiles-{key}-stackingcapacity", config.Piles[key].StackingCapacity);
                api.World.Config.SetInt($"morepiles-{key}-transferquantity", config.Piles[key].TransferQuantity);
            }
        }

        private static MorePilesConfig LoadConfig(ICoreAPI api) => api.LoadModConfig<MorePilesConfig>(jsonConfig);
        private static void GenerateConfig(ICoreAPI api) => api.StoreModConfig(new MorePilesConfig(), jsonConfig);
        private static void GenerateConfig(ICoreAPI api, MorePilesConfig previousConfig) => api.StoreModConfig(new MorePilesConfig(previousConfig), jsonConfig);
    }
}