using MorePiles.Configuration;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Util;

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
        if (!api.Side.IsServer())
        {
            Mod.Logger.Event("started '{0}' mod", Mod.Info.Name);
            return;
        }

        long elapsedMilliseconds = api.World.ElapsedMilliseconds;

        Config = ModConfig.ReadConfig<ConfigMorePiles>(api, "MorePilesConfig.json");

        Dictionary<string, GroundStoragePropertiesExtended> items = DataPile.GetPropsFromAll(api, Config.ItemPiles);
        Dictionary<string, GroundStoragePropertiesExtended> blocks = DataPile.GetPropsFromAll(api, Config.BlockPiles);

        foreach (Item item in api.World.Items)
        {
            if (item.Code == null || item.Id == 0) continue;

            foreach (KeyValuePair<string, GroundStoragePropertiesExtended> props in items)
            {
                if (!item.WildCardMatch(AssetLocation.Create(props.Key))) continue;

                props.Value.EnsurePropertiesNotNull();
                TryRemoveBehaviors(item, props.Value.MorePilesProperties);

                if (GetClassesAsStrings(props.Value.MorePilesProperties) is string[] classes && !classes.Contains(item.GetType().Name))
                {
                    continue;
                }

                if (GetShapeLocation(props.Value.MorePilesProperties) is string shapeLoc && shapeLoc != null && item.Shape?.Base != shapeLoc)
                {
                    continue;
                }

                item.AppendBehavior(props.Value);
                item.AddToCreativeInventory();
                break;
            }
        }

        foreach (Block block in api.World.Blocks)
        {
            if (block.Code == null || block.Id == 0) continue;

            foreach (KeyValuePair<string, GroundStoragePropertiesExtended> props in blocks)
            {
                if (!block.WildCardMatch(AssetLocation.Create(props.Key))) continue;

                props.Value.EnsurePropertiesNotNull();
                TryRemoveBehaviors(block, props.Value.MorePilesProperties);

                if (GetClassesAsStrings(props.Value.MorePilesProperties) is string[] classes && classes != null && !classes.Contains(block.GetType().Name))
                {
                    continue;
                }

                if (GetShapeLocation(props.Value.MorePilesProperties) is string shapeLoc && shapeLoc != null && block.Shape?.Base != shapeLoc)
                {
                    continue;
                }

                block.AppendBehavior(props.Value);
                block.AddToCreativeInventory();
                break;
            }
        }

        Mod.Logger.Event("started '{0}' mod ({1} ms)", Mod.Info.Name, api.World.ElapsedMilliseconds - elapsedMilliseconds);
    }

    private static void TryRemoveBehaviors(CollectibleObject obj, JsonObject props)
    {
        if (props.IsTrue("ForceReplace"))
        {
            obj.RemoveGroundStorableBehaviors();
        }
    }

    private static string GetShapeLocation(JsonObject props)
    {
        return props.KeyExists("MatchesShape") ? props["MatchesShape"].AsString() : null;
    }

    private static string[] GetClassesAsStrings(JsonObject props)
    {
        return props.KeyExists("MatchesClasses") ? props["MatchesClasses"].AsObject<string[]>() : null;
    }
}