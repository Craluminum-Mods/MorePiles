using Vintagestory.API.Common;

[assembly: ModInfo(name: "More Piles", modID: "morepiles", Side = "Universal")]

namespace MorePiles;

public class Core : ModSystem
{
    public static Config Config { get; private set; }

    public override void AssetsFinalize(ICoreAPI api)
    {
        Config = ModConfig.ReadConfig(api);
        api.AppendBehaviors();
        api.World.Logger.Event("started '{0}' mod", Mod.Info.Name);
    }
}