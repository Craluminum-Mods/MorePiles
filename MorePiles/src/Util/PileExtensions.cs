using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MorePiles;

public static class PileExtensions
{
    public static AssetLocation GetModel(this CollectibleObject obj, string key)
    {
        return key switch
        {
            "angledgears" => new AssetLocation("morepiles:shapes/angledgearpile_4"),
            "arrow" => new AssetLocation("morepiles:shapes/arrowpile_32"),
            "axle" => new AssetLocation("morepiles:shapes/axlepile_16"),
            "bamboostakes" => new AssetLocation("morepiles:shapes/bamboostakespile_64"),
            "beeswax" => new AssetLocation("morepiles:shapes/beeswaxpile_8"),
            "bone" => new AssetLocation("morepiles:shapes/bonepile_64"),
            "chutesection" => new AssetLocation("morepiles:shapes/chutesectionpile_8"),
            "cloth" => new AssetLocation("morepiles:shapes/clothpile_12"),
            "drystonefence" => new AssetLocation("morepiles:shapes/drystonefencepile_8"),
            "fencegate" => new AssetLocation("morepiles:shapes/woodenfencegatepile_8"),
            "flaxfibers" => new AssetLocation("morepiles:shapes/flaxfiberspile_16"),
            "flaxtwine" => new AssetLocation("morepiles:shapes/flaxtwinepile_8"),
            "henbox" => new AssetLocation("morepiles:shapes/henboxpile_4"),
            "metalchain" => new AssetLocation("morepiles:shapes/metalchainpile_16"),
            "metallamellae" => new AssetLocation("morepiles:shapes/metallamellaepile_32"),
            "metalscale" => new AssetLocation("morepiles:shapes/metalscalespile_32"),
            "rope" => new AssetLocation("morepiles:shapes/ropepile_32"),
            "sail" => new AssetLocation("morepiles:shapes/sailpile_8"),
            "sign" => new AssetLocation("morepiles:shapes/signpile_8"),
            "stick" => new AssetLocation("morepiles:shapes/stickpile_64"),
            "stone" => new AssetLocation("morepiles:shapes/stonepile_72"),
            "toolrack" => new AssetLocation("morepiles:shapes/toolrackpile_16"),
            "torchholder" => new AssetLocation("morepiles:shapes/torchholderpile_8"),
            "trapdoor" => new AssetLocation("morepiles:shapes/trapdoorpile_8"),
            "fence" => new AssetLocation("morepiles:shapes/woodenfencepile_8"),
            "ironfence" => obj.WildCardMatch("*-base-*") ? new AssetLocation("morepiles:shapes/ironfencepile-base") : new AssetLocation("morepiles:shapes/ironfencepile-top"),
            "ladder" => obj.WildCardMatch("*-rope-*") ? new AssetLocation("morepiles:shapes/ladderpile-rope_8") : new AssetLocation("morepiles:shapes/ladderpile-wood_8"),
            "mostCubicBlocks" => obj.MaxStackSize switch
            {
                _ => obj is BlockLog ? new AssetLocation("morepiles:shapes/cubelogpile_64") : new AssetLocation("morepiles:shapes/cubepile_64"),
            },
        };
    }

    public static int GetShapeElementCount(this ICoreAPI api, string shapePath)
    {
        int elementCount = 0;
        Shape.TryGet(api, shapePath + ".json")?.WalkElements("*", _ => elementCount++);
        return elementCount;
    }

    public static bool GetSprintKey(this CollectibleObject obj, string key)
    {
        return key switch
        {
            "stone" => true,
            _ => obj is Block,
        };
    }

    public static float GetIronFenceRatio(this CollectibleObject obj, int stackingCapacity) => obj.WildCardMatch("*-base-*")
        ? 112 / stackingCapacity
        : 160 / stackingCapacity;
    public static float GetLadderRatio(this CollectibleObject obj, int stackingCapacity) => obj.WildCardMatch("*-rope-*")
        ? 704 / stackingCapacity
        : 320 / stackingCapacity;
}