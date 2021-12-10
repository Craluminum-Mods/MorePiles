using System.Collections;
using Vintagestory.API.Common;

[assembly: ModInfo("MorePiles", Version = "1.2.0",
	Description = "Adds piles for some items and blocks",
		IconPath = "modicon.png",
		Website = "https://github.com/Craluminum2413/MorePiles",
		Authors = new[] { "Craluminum2413" })]

namespace MorePiles
{
	public partial class MorePiles : ModSystem
	{
		public override void StartPre(ICoreAPI api)
		{
			base.StartPre(api);

			try
			{
					MorePilesConfig settingsFromDisk;
					if ((settingsFromDisk = api.LoadModConfig<MorePilesConfig>("MorePilesConfig.json")) == null)
					{
							api.StoreModConfig<MorePilesConfig>(MorePilesConfig.Loaded, "MorePilesConfig.json");
					}
					else
					{
							MorePilesConfig.Loaded = settingsFromDisk;
					}
					foreach (var part in settingsFromDisk)
					{
								var name = nameof(part);
								var capacity = part.StackingCapacity;
								api.World.Config.SetBool($"{name}IsEnabled", part.Enabled);
								api.World.Config.SetInt($"{name}StackingCapacity{capacity}", capacity);
					}
			}
			catch
			{
					api.StoreModConfig<MorePilesConfig>(MorePilesConfig.Loaded, "MorePilesConfig.json");
			}
		}
	}

	public class Part<T>
	{
			public bool Enabled { get; set; }
			public int StackingCapacity { get; set; }
			public string StackingCapacities { get; set; } = "";

			public Part(bool enabled, int stackingCapacity, string stackingCapacities)
			{
					Enabled = enabled;
					StackingCapacity = stackingCapacity;
					StackingCapacities = stackingCapacities;
			}
	}

	public class MorePilesConfig /* : IEnumerable */
	{
		public static MorePilesConfig Loaded { get; set; } = new MorePilesConfig();

		public Part<bool> PileAngledGear { get; set; } = new Part<bool>(true, 32, "[16, 32]");
		public Part<bool> PileArrow { get; set; } = new Part<bool>(true, 64, "[32, 48, 64, 80, 96, 112, 128]");
		public Part<bool> PileAxle { get; set; } = new Part<bool>(true, 16, "None");
		public Part<bool> PileBambooStakes { get; set; } = new Part<bool>(true, 128, "[16, 32, 64, 128, 256]");
		public Part<bool> PileBeeswax { get; set; } = new Part<bool>(true, 64, "[32, 64, 128, 256]");
		public Part<bool> PileBone { get; set; } = new Part<bool>(true, 128, "[32, 64, 128, 256]");
		public Part<bool> PileChuteSection { get; set; } = new Part<bool>(true, 8, "None");
		public Part<bool> PileCloth { get; set; } = new Part<bool>(true, 12, "[4, 6, 12]");
		public Part<bool> PileCookingPotBurnt { get; set; } = new Part<bool>(false, 12, "[Wait for a fix in vanilla]");
		public Part<bool> PileDryStoneFence { get; set; } = new Part<bool>(true, 32, "[8, 16, 32]");
		public Part<bool> PileFenceGateWooden { get; set; } = new Part<bool>(true, 64, "[8, 16, 32, 64]");
		public Part<bool> PileFenceWooden { get; set; } = new Part<bool>(true, 64, "[8, 16, 32, 64]");
		public Part<bool> PileFlaxFibers { get; set; } = new Part<bool>(true, 128, "[32, 64, 128]");
		public Part<bool> PileFlaxTwine { get; set; } = new Part<bool>(true, 64, "[32, 64]");
		public Part<bool> PileFlowerpotBurnt { get; set; } = new Part<bool>(false, 8, "[Wait for a fix in vanilla]");
		public Part<bool> PileHenbox { get; set; } = new Part<bool>(true, 64, "[8, 16, 32, 64, 128]");
		public Part<bool> PileHoneycomb { get; set; } = new Part<bool>(true, 64, "[32, 64]");
		public Part<bool> PileIronBloom { get; set; } = new Part<bool>(true, 64, "[32, 64]");
		public Part<bool> PileIronFence { get; set; } = new Part<bool>(true, 16, "None");
		public Part<bool> PileLadder { get; set; } = new Part<bool>(true, 64, "[8, 16, 32, 64]");
		public Part<bool> PileMetalChain { get; set; } = new Part<bool>(true, 16, "[16]");
		public Part<bool> PileMetalLamellae { get; set; } = new Part<bool>(true, 16, "[16]");
		public Part<bool> PileMetalScales { get; set; } = new Part<bool>(true, 16, "[16]");
		public Part<bool> PilePainting { get; set; } = new Part<bool>(true, 16, "None");
		public Part<bool> PilePoultice { get; set; } = new Part<bool>(false, 64, "None");
		public Part<bool> PileSail { get; set; } = new Part<bool>(true, 8, "[4, 8]");
		public Part<bool> PileSign { get; set; } = new Part<bool>(true, 64, "[64]");
		public Part<bool> PileStick { get; set; } = new Part<bool>(true, 128, "[64, 128, 256]");
		public Part<bool> PileSticksLayer { get; set; } = new Part<bool>(true, 16, "[4, 8, 16]");
		public Part<bool> PileStone { get; set; } = new Part<bool>(false, 64, "[64, 128, 256]");
		public Part<bool> PileToolrack { get; set; } = new Part<bool>(true, 32, "[8, 16, 32, 64]");
		public Part<bool> PileTorchholder { get; set; } = new Part<bool>(true, 8, "[8, 16]");
		public Part<bool> PileTrapdoor { get; set; } = new Part<bool>(true, 64, "[8, 16, 32, 64]");
		public Part<bool> PileTroughLarge { get; set; } = new Part<bool>(true, 64, "[64]");
		public Part<bool> PileTroughSmall { get; set; } = new Part<bool>(true, 64, "[64]");

    // IEnumerator IEnumerable.GetEnumerator()
    // {
		// 	return (Loaded as IEnumerable).GetEnumerator();
    // }
  }
}