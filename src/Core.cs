using Vintagestory.API.Common;

[assembly: ModInfo("MorePiles", Version = "1.1.2",
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

			var capacityPAG = MorePilesConfig.Loaded.PileAngledGear.StackingCapacity;
			api.World.Config.SetBool("PileAngledGearIsEnabled", MorePilesConfig.Loaded.PileAngledGear.IsEnabled);
			api.World.Config.SetInt($"PileAngledGearStackingCapacity{capacityPAG}", capacityPAG);

			var capacityPArr = MorePilesConfig.Loaded.PileArrow.StackingCapacity;
			api.World.Config.SetBool("PileArrowIsEnabled", MorePilesConfig.Loaded.PileArrow.IsEnabled);
			api.World.Config.SetInt($"PileArrowStackingCapacity{capacityPArr}", capacityPArr);

			var capacityPAx = MorePilesConfig.Loaded.PileAxle.StackingCapacity;
			api.World.Config.SetBool("PileAxleIsEnabled", MorePilesConfig.Loaded.PileAxle.IsEnabled);
			api.World.Config.SetInt($"PileAxleStackingCapacity{capacityPAx}", capacityPAx);

			var capacityPBS = MorePilesConfig.Loaded.PileBambooStakes.StackingCapacity;
			api.World.Config.SetBool("PileBambooStakesIsEnabled", MorePilesConfig.Loaded.PileBambooStakes.IsEnabled);
			api.World.Config.SetInt($"PileBambooStakesStackingCapacity{capacityPBS}", capacityPBS);

			var capacityPBee = MorePilesConfig.Loaded.PileBeeswax.StackingCapacity;
			api.World.Config.SetBool("PileBeeswaxIsEnabled", MorePilesConfig.Loaded.PileBeeswax.IsEnabled);
			api.World.Config.SetInt($"PileBeeswaxStackingCapacity{capacityPBee}", capacityPBee);

			var capacityPBo = MorePilesConfig.Loaded.PileBone.StackingCapacity;
			api.World.Config.SetBool("PileBoneIsEnabled", MorePilesConfig.Loaded.PileBone.IsEnabled);
			api.World.Config.SetInt($"PileBoneStackingCapacity{capacityPBo}", capacityPBo);

			var capacityPCS = MorePilesConfig.Loaded.PileChuteSection.StackingCapacity;
			api.World.Config.SetBool("PileChuteSectionIsEnabled", MorePilesConfig.Loaded.PileChuteSection.IsEnabled);
			api.World.Config.SetInt($"PileChuteSectionStackingCapacity{capacityPCS}", capacityPCS);
			
			var capacityPCl = MorePilesConfig.Loaded.PileCloth.StackingCapacity;
			api.World.Config.SetBool("PileClothIsEnabled", MorePilesConfig.Loaded.PileCloth.IsEnabled);
			api.World.Config.SetInt($"PileClothStackingCapacity{capacityPCl}", capacityPCl);
			
			var capacityPCPB = MorePilesConfig.Loaded.PileCookingPotBurnt.StackingCapacity;
			api.World.Config.SetBool("PileCookingPotBurntIsEnabled", MorePilesConfig.Loaded.PileCookingPotBurnt.IsEnabled);
			api.World.Config.SetInt($"PileCookingPotBurntStackingCapacity{capacityPCPB}", capacityPCPB);
			
			var capacityPDSF = MorePilesConfig.Loaded.PileDryStoneFence.StackingCapacity;
			api.World.Config.SetBool("PileDryStoneFenceIsEnabled", MorePilesConfig.Loaded.PileDryStoneFence.IsEnabled);
			api.World.Config.SetInt($"PileDryStoneFenceStackingCapacity{capacityPDSF}", capacityPDSF);
			
			var capacityPFGW = MorePilesConfig.Loaded.PileFenceGateWooden.StackingCapacity;
			api.World.Config.SetBool("PileFenceGateWoodenIsEnabled", MorePilesConfig.Loaded.PileFenceGateWooden.IsEnabled);
			api.World.Config.SetInt($"PileFenceGateWoodenStackingCapacity{capacityPFGW}", capacityPFGW);
			
			var capacityPFW = MorePilesConfig.Loaded.PileFenceWooden.StackingCapacity;
			api.World.Config.SetBool("PileFenceWoodenIsEnabled", MorePilesConfig.Loaded.PileFenceWooden.IsEnabled);
			api.World.Config.SetInt($"PileFenceWoodenStackingCapacity{capacityPFW}", capacityPFW);
			
			var capacityPFF = MorePilesConfig.Loaded.PileFlaxFibers.StackingCapacity;
			api.World.Config.SetBool("PileFlaxFibersIsEnabled", MorePilesConfig.Loaded.PileFlaxFibers.IsEnabled);
			api.World.Config.SetInt($"PileFlaxFibersStackingCapacity{capacityPFF}", capacityPFF);
			
			var capacityPFT = MorePilesConfig.Loaded.PileFlaxTwine.StackingCapacity;
			api.World.Config.SetBool("PileFlaxTwineIsEnabled", MorePilesConfig.Loaded.PileFlaxTwine.IsEnabled);
			api.World.Config.SetInt($"PileFlaxTwineStackingCapacity{capacityPFT}", capacityPFT);
			
			var capacityPFB = MorePilesConfig.Loaded.PileFlowerpotBurnt.StackingCapacity;
			api.World.Config.SetBool("PileFlowerpotBurntIsEnabled", MorePilesConfig.Loaded.PileFlowerpotBurnt.IsEnabled);
			api.World.Config.SetInt($"PileFlowerpotBurntStackingCapacity{capacityPFB}", capacityPFB);
			
			var capacityPHo = MorePilesConfig.Loaded.PileHenbox.StackingCapacity;
			api.World.Config.SetBool("PileHenboxIsEnabled", MorePilesConfig.Loaded.PileHenbox.IsEnabled);
			api.World.Config.SetInt($"PileHenboxStackingCapacity{capacityPHo}", capacityPHo);
			
			var capacityPHC = MorePilesConfig.Loaded.PileHoneycomb.StackingCapacity;
			api.World.Config.SetBool("PileHoneycombIsEnabled", MorePilesConfig.Loaded.PileHoneycomb.IsEnabled);
			api.World.Config.SetInt($"PileHoneycombStackingCapacity{capacityPHC}", capacityPHC);
			
			var capacityPIB = MorePilesConfig.Loaded.PileIronBloom.StackingCapacity;
			api.World.Config.SetBool("PileIronBloomIsEnabled", MorePilesConfig.Loaded.PileIronBloom.IsEnabled);
			api.World.Config.SetInt($"PileIronBloomStackingCapacity{capacityPIB}", capacityPIB);
			
			var capacityPIF = MorePilesConfig.Loaded.PileIronFence.StackingCapacity;
			api.World.Config.SetBool("PileIronFenceIsEnabled", MorePilesConfig.Loaded.PileIronFence.IsEnabled);
			api.World.Config.SetInt($"PileIronFenceStackingCapacity{capacityPIF}", capacityPIF);
			
			var capacityPLa = MorePilesConfig.Loaded.PileLadder.StackingCapacity;
			api.World.Config.SetBool("PileLadderIsEnabled", MorePilesConfig.Loaded.PileLadder.IsEnabled);
			api.World.Config.SetInt($"PileLadderStackingCapacity{capacityPLa}", capacityPLa);
			
			var capacityPMC = MorePilesConfig.Loaded.PileMetalChain.StackingCapacity;
			api.World.Config.SetBool("PileMetalChainIsEnabled", MorePilesConfig.Loaded.PileMetalChain.IsEnabled);
			api.World.Config.SetInt($"PileMetalChainStackingCapacity{capacityPMC}", capacityPMC);

			var capacityPML = MorePilesConfig.Loaded.PileMetalLamellae.StackingCapacity;
			api.World.Config.SetBool("PileMetalLamellaeIsEnabled", MorePilesConfig.Loaded.PileMetalLamellae.IsEnabled);
			api.World.Config.SetInt($"PileMetalLamellaeStackingCapacity{capacityPML}", capacityPML);

			var capacityPMS = MorePilesConfig.Loaded.PileMetalScales.StackingCapacity;
			api.World.Config.SetBool("PileMetalScalesIsEnabled", MorePilesConfig.Loaded.PileMetalScales.IsEnabled);
			api.World.Config.SetInt($"PileMetalScalesStackingCapacity{capacityPMS}", capacityPMS);

			var capacityPPa = MorePilesConfig.Loaded.PilePainting.StackingCapacity;
			api.World.Config.SetBool("PilePaintingIsEnabled", MorePilesConfig.Loaded.PilePainting.IsEnabled);
			api.World.Config.SetInt($"PilePaintingStackingCapacity{capacityPPa}", capacityPPa);

			var capacityPPo = MorePilesConfig.Loaded.PilePoultice.StackingCapacity;
			api.World.Config.SetBool("PilePoulticeIsEnabled", MorePilesConfig.Loaded.PilePoultice.IsEnabled);
			api.World.Config.SetInt($"PilePoulticeStackingCapacity{capacityPPo}", capacityPPo);

			var capacityPSa = MorePilesConfig.Loaded.PileSail.StackingCapacity;
			api.World.Config.SetBool("PileSailIsEnabled", MorePilesConfig.Loaded.PileSail.IsEnabled);
			api.World.Config.SetInt($"PileSailStackingCapacity{capacityPSa}", capacityPSa);

			var capacityPSi = MorePilesConfig.Loaded.PileSign.StackingCapacity;
			api.World.Config.SetBool("PileSignIsEnabled", MorePilesConfig.Loaded.PileSign.IsEnabled);
			api.World.Config.SetInt($"PileSignStackingCapacity{capacityPSi}", capacityPSi);

			var capacityPSti = MorePilesConfig.Loaded.PileStick.StackingCapacity;
			api.World.Config.SetBool("PileStickIsEnabled", MorePilesConfig.Loaded.PileStick.IsEnabled);
			api.World.Config.SetInt($"PileStickStackingCapacity{capacityPSti}", capacityPSti);

			var capacityPSL = MorePilesConfig.Loaded.PileSticksLayer.StackingCapacity;
			api.World.Config.SetBool("PileSticksLayerIsEnabled", MorePilesConfig.Loaded.PileSticksLayer.IsEnabled);
			api.World.Config.SetInt($"PileSticksLayerStackingCapacity{capacityPSL}", capacityPSL);

			var capacityPSto = MorePilesConfig.Loaded.PileStone.StackingCapacity;
			api.World.Config.SetBool("PileStoneIsEnabled", MorePilesConfig.Loaded.PileStone.IsEnabled);
			api.World.Config.SetInt($"PileStoneStackingCapacity{capacityPSto}", capacityPSto);

			var capacityPToo = MorePilesConfig.Loaded.PileToolrack.StackingCapacity;
			api.World.Config.SetBool("PileToolrackIsEnabled", MorePilesConfig.Loaded.PileToolrack.IsEnabled);
			api.World.Config.SetInt($"PileToolrackStackingCapacity{capacityPToo}", capacityPToo);

			var capacityPTh = MorePilesConfig.Loaded.PileTorchholder.StackingCapacity;
			api.World.Config.SetBool("PileTorchholderIsEnabled", MorePilesConfig.Loaded.PileTorchholder.IsEnabled);
			api.World.Config.SetInt($"PileTorchholderStackingCapacity{capacityPTh}", capacityPTh);

			var capacityPTra = MorePilesConfig.Loaded.PileTrapdoor.StackingCapacity;
			api.World.Config.SetBool("PileTrapdoorIsEnabled", MorePilesConfig.Loaded.PileTrapdoor.IsEnabled);
			api.World.Config.SetInt($"PileTrapdoorStackingCapacity{capacityPTra}", capacityPTra);

			var capacityPTL = MorePilesConfig.Loaded.PileTroughLarge.StackingCapacity;
			api.World.Config.SetBool("PileTroughLargeIsEnabled", MorePilesConfig.Loaded.PileTroughLarge.IsEnabled);
			api.World.Config.SetInt($"PileTroughLargeStackingCapacity{capacityPTL}", capacityPTL);

			var capacityPTS = MorePilesConfig.Loaded.PileTroughSmall.StackingCapacity;
			api.World.Config.SetBool("PileTroughSmallIsEnabled", MorePilesConfig.Loaded.PileTroughSmall.IsEnabled);
			api.World.Config.SetInt($"PileTroughSmallStackingCapacity{capacityPTS}", capacityPTS);
		}
	}
}