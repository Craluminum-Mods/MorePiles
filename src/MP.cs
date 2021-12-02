using Vintagestory.API.Common;

[assembly: ModInfo( "MorePiles", Version = "1.1.2",
	Description = "Adds piles for some items and blocks",
	Website     = "https://github.com/Craluminum2413/MorePiles",
	Authors     = new []{ "Craluminum2413" } )]

namespace MorePiles
{
	public class MorePiles : ModSystem
	{
		public override void StartPre(ICoreAPI api)
		{
			base.StartPre(api);

			try
			{
				MorePilesConfig FromDisk;
				if ((FromDisk = api.LoadModConfig<MorePilesConfig>("MorePilesConfig.json")) == null)
				{
					api.StoreModConfig<MorePilesConfig>(MorePilesConfig.Loaded, "MorePilesConfig.json");
				}
				else MorePilesConfig.Loaded = FromDisk;
			}
			catch
			{
				api.StoreModConfig<MorePilesConfig>(MorePilesConfig.Loaded, "MorePilesConfig.json");
			}

			api.World.Config.SetBool("MPangledgear", MorePilesConfig.Loaded.PileAngledGear);
			api.World.Config.SetBool("MParrow", MorePilesConfig.Loaded.PileArrow);
			// api.World.Config.SetBool("MParrow128", MorePilesConfig.Loaded.PileArrowStackingCapacity128);
			// api.World.Config.SetBool("MParrow112", MorePilesConfig.Loaded.PileArrowStackingCapacity112);
			// api.World.Config.SetBool("MParrow96", MorePilesConfig.Loaded.PileArrowStackingCapacity96);
			// api.World.Config.SetBool("MParrow80", MorePilesConfig.Loaded.PileArrowStackingCapacity80);
			// api.World.Config.SetBool("MParrow64", MorePilesConfig.Loaded.PileArrowStackingCapacity64);
			// api.World.Config.SetBool("MParrow48", MorePilesConfig.Loaded.PileArrowStackingCapacity48);
			// api.World.Config.SetBool("MParrow32", MorePilesConfig.Loaded.PileArrowStackingCapacity32);
			api.World.Config.SetBool("MPaxle", MorePilesConfig.Loaded.PileAxle);
			api.World.Config.SetBool("MPbamboostakes", MorePilesConfig.Loaded.PileBambooStakes);
			api.World.Config.SetBool("MPbeeswax", MorePilesConfig.Loaded.PileBeeswax);
			api.World.Config.SetBool("MPbone", MorePilesConfig.Loaded.PileBone);
			api.World.Config.SetBool("MPchutesection", MorePilesConfig.Loaded.PileChuteSection);
			api.World.Config.SetBool("MPcloth", MorePilesConfig.Loaded.PileCloth);
			api.World.Config.SetBool("MPcookingpotburnt", MorePilesConfig.Loaded.PileCookingPotBurnt);
			api.World.Config.SetBool("MPdrystonefence", MorePilesConfig.Loaded.PileDryStoneFence);
			api.World.Config.SetBool("MPfencegatewooden", MorePilesConfig.Loaded.PileFenceGateWooden);			
			api.World.Config.SetBool("MPfencewooden", MorePilesConfig.Loaded.PileFenceWooden);
			api.World.Config.SetBool("MPflaxfibers", MorePilesConfig.Loaded.PileFlaxFibers);
			api.World.Config.SetBool("MPflaxtwine", MorePilesConfig.Loaded.PileFlaxTwine);
			api.World.Config.SetBool("MPflowerpotburnt", MorePilesConfig.Loaded.PileFlowepotBurnt);
			api.World.Config.SetBool("MPhenbox", MorePilesConfig.Loaded.PileHenbox);
			api.World.Config.SetBool("MPhoneycomb", MorePilesConfig.Loaded.PileHoneycomb);
			api.World.Config.SetBool("MPironbloom", MorePilesConfig.Loaded.PileIronBloom);
			api.World.Config.SetBool("MPironfence", MorePilesConfig.Loaded.PileIronFence);
			api.World.Config.SetBool("MPladder", MorePilesConfig.Loaded.PileLadder);
			api.World.Config.SetBool("MPmetalchain", MorePilesConfig.Loaded.PileMetalChain);
			api.World.Config.SetBool("MPmetallamellae", MorePilesConfig.Loaded.PileMetalLamellae);
			api.World.Config.SetBool("MPmetalscales", MorePilesConfig.Loaded.PileMetalScales);
			api.World.Config.SetBool("MPpainting", MorePilesConfig.Loaded.PilePainting);
			api.World.Config.SetBool("MPpoultice", MorePilesConfig.Loaded.PilePoultice);
			api.World.Config.SetBool("MPsail", MorePilesConfig.Loaded.PileSail);
			api.World.Config.SetBool("MPsign", MorePilesConfig.Loaded.PileSign);
			api.World.Config.SetBool("MPstick", MorePilesConfig.Loaded.PileStick);
			api.World.Config.SetBool("MPstickslayer", MorePilesConfig.Loaded.PileSticksLayer);
			api.World.Config.SetBool("MPstone", MorePilesConfig.Loaded.PileStone);
			api.World.Config.SetBool("MPtoolrack", MorePilesConfig.Loaded.PileToolrack);
			api.World.Config.SetBool("MPtorchholder", MorePilesConfig.Loaded.PileTorchholder);
			api.World.Config.SetBool("MPtrapdoor", MorePilesConfig.Loaded.PileTrapdoor);
			api.World.Config.SetBool("MPtroughlarge", MorePilesConfig.Loaded.PileTroughLarge);
			api.World.Config.SetBool("MPtroughsmall", MorePilesConfig.Loaded.PileTroughSmall);
		}

		public class MorePilesConfig
		{
			public static MorePilesConfig Loaded { get; set; } = new MorePilesConfig();
			public bool PileAngledGear { get; set; } = true;
			public bool PileArrow { get; set; } = true;
			// public bool PileArrowStackingCapacity128 { get; set; } = true;
			// public bool PileArrowStackingCapacity112 { get; set; } = false;
			// public bool PileArrowStackingCapacity96 { get; set; } = false;
			// public bool PileArrowStackingCapacity80 { get; set; } = false;
			// public bool PileArrowStackingCapacity64 { get; set; } = false;
			// public bool PileArrowStackingCapacity48 { get; set; } = false;
			// public bool PileArrowStackingCapacity32 { get; set; } = false;
			public bool PileAxle { get; set; } = true;
			public bool PileBambooStakes { get; set; } = true;
			public bool PileBeeswax { get; set; } = true;
			public bool PileBone { get; set; } = true;
			public bool PileChuteSection { get; set; } = true;
			public bool PileCloth { get; set; } = true;
			public bool PileCookingPotBurnt { get; set; } = false;
			public bool PileDryStoneFence { get; set; } = true;
			public bool PileFenceGateWooden { get; set; } = true;
			public bool PileFenceWooden { get; set; } = true;
			public bool PileFlaxFibers { get; set; } = true;
			public bool PileFlaxTwine { get; set; } = true;
			public bool PileFlowepotBurnt { get; set; } = false;
			public bool PileHenbox { get; set; } = true;
			public bool PileHoneycomb { get; set; } = true;
			public bool PileIronBloom { get; set; } = true;
			public bool PileIronFence { get; set; } = true;
			public bool PileLadder { get; set; } = true;
			public bool PileMetalChain { get; set; } = true;
			public bool PileMetalLamellae { get; set; } = true;
			public bool PileMetalScales { get; set; } = true;
			public bool PilePainting { get; set; } = true;
			public bool PilePoultice { get; set; } = false;
			public bool PileSail { get; set; } = true;
			public bool PileSign { get; set; } = true;
			public bool PileStick { get; set; } = true;
			public bool PileSticksLayer { get; set; } = true;
			public bool PileStone { get; set; } = false;
			public bool PileToolrack { get; set; } = true;
			public bool PileTorchholder { get; set; } = true;
			public bool PileTrapdoor { get; set; } = true;
			public bool PileTroughLarge { get; set; } = true;
			public bool PileTroughSmall { get; set; } = true;
		}
	}
}