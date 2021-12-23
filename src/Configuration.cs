using System.Collections.Generic;
using Vintagestory.API.Common;
using MorePiles.Constructor;
using MorePiles.List;

[assembly: ModInfo("MorePiles",
  Description = "Adds piles for some items and blocks",
  Website = "https://github.com/Craluminum2413/MorePiles",
  Authors = new[] { "Craluminum2413" })]

namespace MorePiles
{
  public class Core : ModSystem
	{
    public override void StartPre(ICoreAPI api)
		{
			base.StartPre(api);

			MorePilesConfig settingsFromDisk;

			try
			{
				settingsFromDisk = api.LoadModConfig<MorePilesConfig>("MorePilesConfig.json");
			}
			catch
			{
				settingsFromDisk = null;
			}

			if (settingsFromDisk is null)
			{
				settingsFromDisk = MorePilesConfig.Loaded;
				api.StoreModConfig<MorePilesConfig>(MorePilesConfig.Loaded, "MorePilesConfig.json");
			}

			foreach (KeyValuePair<string, Part> p in settingsFromDisk)
			{
				api.World.Config.SetBool($"Pile{p.Key}Enabled", p.Value.Enabled);
				api.World.Config.SetInt($"Pile{p.Key}StackingCapacity", p.Value.StackingCapacity);
			}
		}
	}
}