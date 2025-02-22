using MorePiles.Configuration;
using System.Collections.Generic;
using Vintagestory.API.Common;

namespace MorePiles;

public class Core : ModSystem
{
    public static ConfigMorePiles Config { get; private set; }

    public Dictionary<string, DataPile> DefaultItemPiles { get; private set; }
    public Dictionary<string, DataPile> DefaultBlockPiles { get; private set; }

    public static Core GetInstance(ICoreAPI api) => api.ModLoader.GetModSystem<Core>();

    public override void AssetsLoaded(ICoreAPI api)
    {
        DefaultItemPiles = api.Assets.Get(new AssetLocation("morepiles:config/default-item-piles.json")).ToObject<Dictionary<string, DataPile>>();
        DefaultBlockPiles = api.Assets.Get(new AssetLocation("morepiles:config/default-block-piles.json")).ToObject<Dictionary<string, DataPile>>();
    }

    public override void AssetsFinalize(ICoreAPI api)
    {
        long elapsedMilliseconds = api.World.ElapsedMilliseconds;

        Config = ModConfig.ReadConfig<ConfigMorePiles>(api, "MorePilesConfig.json");

        Dictionary<string, GroundStoragePropertiesExtended> items = DataPile.GetPropsFromAll(api, Config.ItemPiles);
        Dictionary<string, GroundStoragePropertiesExtended> blocks = DataPile.GetPropsFromAll(api, Config.BlockPiles);

        foreach (CollectibleObject obj in api.World.Collectibles)
        {
            if (obj.Code == null || obj.Id == 0) continue;

            switch (obj.ItemClass)
            {
                case EnumItemClass.Block:
                    foreach (KeyValuePair<string, GroundStoragePropertiesExtended> props in blocks)
                    {
                        if (!obj.WildCardMatch(AssetLocation.Create(props.Key))) continue;

                        if (props.Value.MorePilesProperties?.IsTrue("ForceReplace") == true)
                        {
                            obj.RemoveGroundStorableBehaviors();
                        }

                        obj.AppendBehavior(props.Value);
                        obj.AddToCreativeInventory();
                        break;
                    }
                    break;
                case EnumItemClass.Item:
                    foreach (KeyValuePair<string, GroundStoragePropertiesExtended> props in items)
                    {
                        if (!obj.WildCardMatch(AssetLocation.Create(props.Key))) continue;

                        if (props.Value.MorePilesProperties?.IsTrue("ForceReplace") == true)
                        {
                            obj.RemoveGroundStorableBehaviors();
                        }

                        obj.AppendBehavior(props.Value);
                        obj.AddToCreativeInventory();
                        break;
                    }
                    break;
            }
        }

        Mod.Logger.Event("started '{0}' mod ({1} ms)", Mod.Info.Name, api.World.ElapsedMilliseconds - elapsedMilliseconds);
    }
}