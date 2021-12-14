using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using Vintagestory.API.Common;

[assembly: ModInfo("MorePiles", Version = "1.2.0",
  Description = "Adds piles for some items and blocks",
    IconPath = "modicon.png",
    Website = "https://github.com/Craluminum2413/MorePiles",
    Authors = new[] { "Craluminum2413" })]

namespace MorePiles
{
  public class MorePiles : ModSystem
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

			foreach (KeyValuePair<string, Pile> pair in settingsFromDisk)
			{
				api.World.Config.SetBool($"Pile{pair.Key}IsEnabled", pair.Value.Enabled);
				api.World.Config.SetInt($"Pile{pair.Key}StackingCapacity", pair.Value.StackingCapacity);
			}
		}
	}

	public class Pile
	{
		public bool Enabled { get; set; }
		public int StackingCapacity { get; set; }
		public string StackingCapacities { get; set; }

    public Pile(bool enabled, int stackingCapacity, string stackingCapacities)
    {
      Enabled = enabled;
      StackingCapacity = stackingCapacity;
      StackingCapacities = stackingCapacities;
    }
	}

	[JsonObject]
	public class MorePilesConfig : IEnumerable<KeyValuePair<string, Pile>>
	{
		public static MorePilesConfig Loaded { get; set; } = new MorePilesConfig();

		public Pile AngledGear { get; set; } = new Pile(true, 32, "[16, 32]");
		public Pile Arrow { get; set; } = new Pile(true, 64, "[32, 48, 64, 80, 96, 112, 128]");
		public Pile Axle { get; set; } = new Pile(true, 16, "None");
		public Pile BambooStakes { get; set; } = new Pile(true, 128, "[16, 32, 64, 128, 256]");
		public Pile Beeswax { get; set; } = new Pile(true, 64, "[32, 64, 128, 256]");
		public Pile Bone { get; set; } = new Pile(true, 128, "[32, 64, 128, 256]");
		public Pile ChuteSection { get; set; } = new Pile(true, 8, "None");
		public Pile Cloth { get; set; } = new Pile(true, 12, "[4, 6, 12]");
		public Pile CookingPotBurnt { get; set; } = new Pile(false, 12, "[Wait for a fix in vanilla]");
		public Pile DryStoneFence { get; set; } = new Pile(true, 32, "[8, 16, 32]");
		public Pile FenceGateWooden { get; set; } = new Pile(true, 64, "[8, 16, 32, 64]");
		public Pile FenceWooden { get; set; } = new Pile(true, 64, "[8, 16, 32, 64]");
		public Pile FlaxFibers { get; set; } = new Pile(true, 128, "[32, 64, 128]");
		public Pile FlaxTwine { get; set; } = new Pile(true, 64, "[32, 64]");
		public Pile FlowerpotBurnt { get; set; } = new Pile(false, 8, "[Wait for a fix in vanilla]");
		public Pile Henbox { get; set; } = new Pile(true, 64, "[8, 16, 32, 64, 128]");
		public Pile Honeycomb { get; set; } = new Pile(true, 64, "[32, 64]");
		public Pile IronBloom { get; set; } = new Pile(true, 64, "[32, 64]");
		public Pile IronFence { get; set; } = new Pile(true, 16, "None");
		public Pile Ladder { get; set; } = new Pile(true, 64, "[8, 16, 32, 64]");
		public Pile MetalChain { get; set; } = new Pile(true, 16, "[16]");
		public Pile MetalLamellae { get; set; } = new Pile(true, 16, "[16]");
		public Pile MetalScales { get; set; } = new Pile(true, 16, "[16]");
		public Pile Painting { get; set; } = new Pile(true, 16, "None");
		public Pile Poultice { get; set; } = new Pile(false, 64, "[Wait for a fix in vanilla]");
		public Pile Sail { get; set; } = new Pile(true, 8, "[4, 8]");
		public Pile Sign { get; set; } = new Pile(true, 64, "[64]");
		public Pile Stick { get; set; } = new Pile(true, 128, "[64, 128, 256]");
		public Pile SticksLayer { get; set; } = new Pile(true, 16, "[4, 8, 16]");
		public Pile Stone { get; set; } = new Pile(false, 64, "[Wait for a fix in vanilla]");
		public Pile Toolrack { get; set; } = new Pile(true, 32, "[8, 16, 32, 64]");
		public Pile Torchholder { get; set; } = new Pile(true, 8, "[8, 16]");
		public Pile Trapdoor { get; set; } = new Pile(true, 64, "[8, 16, 32, 64]");
		public Pile TroughLarge { get; set; } = new Pile(true, 64, "[64]");
		public Pile TroughSmall { get; set; } = new Pile(true, 64, "[64]");

		private static readonly PropertyInfo[] propertyInfos = typeof(MorePilesConfig).GetProperties()
			.Where(propertyInfo => propertyInfo.PropertyType == typeof(Pile)).ToArray();

		public IEnumerator<KeyValuePair<string, Pile>> GetEnumerator()
		{
			return propertyInfos.Select(propertyInfo => new KeyValuePair<string, Pile>(propertyInfo.Name, (Pile)propertyInfo.GetValue(this))).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}