
namespace MorePiles
{
  public partial class MorePiles
  {
    public class MorePilesConfig
		{
			public static MorePilesConfig Loaded { get; set; } = new MorePilesConfig();

			public class Part<T>
			{
				public bool IsEnabled;
				public int StackingCapacity;
				public readonly string StackingCapacities;

				public Part(bool IsEnabled, int StackingCapacity, string StackingCapacities)
				{
					this.IsEnabled = IsEnabled;
					this.StackingCapacity = StackingCapacity;
					this.StackingCapacities = StackingCapacities;
				}
				public Part(bool IsEnabled, int StackingCapacity)
				{
					this.IsEnabled = IsEnabled;
					this.StackingCapacity = StackingCapacity;
				}
			}

			public Part<bool> PileArrow { get; set; } = new Part<bool>(true, 64, "[32, 48, 64, 80, 96, 112, 128]");
			public Part<bool> PileAngledGear { get; set; } = new Part<bool>(true, 32, "[16, 32]");
			public Part<bool> PileAxle { get; set; } = new Part<bool>(true, 16);
			public Part<bool> PileBambooStakes { get; set; } = new Part<bool>(true, 128, "[16, 32, 64, 128, 256]");
			public Part<bool> PileBeeswax { get; set; } = new Part<bool>(true, 64, "[32, 64, 128, 256]");
			public Part<bool> PileBone { get; set; } = new Part<bool>(true, 128, "[32, 64, 128, 256]");
			public Part<bool> PileChuteSection { get; set; } = new Part<bool>(true, 8);
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
			public Part<bool> PileIronFence { get; set; } = new Part<bool>(true, 16);
			public Part<bool> PileLadder { get; set; } = new Part<bool>(true, 64, "[8, 16, 32, 64]");
			public Part<bool> PileMetalChain { get; set; } = new Part<bool>(true, 16, "[16]");
			public Part<bool> PileMetalLamellae { get; set; } = new Part<bool>(true, 16, "[16]");
			public Part<bool> PileMetalScales { get; set; } = new Part<bool>(true, 16, "[16]");
			public Part<bool> PilePainting { get; set; } = new Part<bool>(true, 16);
			public Part<bool> PilePoultice { get; set; } = new Part<bool>(false, 64);
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
		}
	}
}