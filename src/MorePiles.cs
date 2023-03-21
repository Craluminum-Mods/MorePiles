
using MorePiles.Configuration;
using Vintagestory.API.Common;

[assembly: ModInfo("More Piles",
    Authors = new[] { "Craluminum2413" })]

namespace MorePiles
{
    public class MorePiles : ModSystem
    {
        public override bool ShouldLoad(EnumAppSide forSide) => forSide == EnumAppSide.Server;

        public override void StartPre(ICoreAPI api)
        {
            base.StartPre(api);
            ModConfig.ReadConfig(api);
            api.World.Logger.Event("started 'More Piles' mod");
        }

        public override void AssetsFinalize(ICoreAPI api)
        {
            api.AppendBehaviors();
        }
    }
}