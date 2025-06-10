using HarmonyLib;
using System.Runtime.CompilerServices;
using Vintagestory.API.Client;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MorePiles;

[HarmonyPatch]
[HarmonyPatch(typeof(BlockGroundStorage), nameof(BlockGroundStorage.GetPlacedBlockInteractionHelp))]
public static class FixVanillaBugs
{
    [HarmonyReversePatch]
    [MethodImpl(MethodImplOptions.NoInlining)]
    public static WorldInteraction[] Base(this BlockGroundStorage instance, IWorldAccessor world, BlockSelection selection, IPlayer forPlayer)
    {
        return default;
    }

    public static bool Prefix(BlockGroundStorage __instance, ref WorldInteraction[] __result, IWorldAccessor world, BlockSelection selection, IPlayer forPlayer)
    {
        try
        {
            __result = Base(__instance, world, selection, forPlayer);
            return false;
        }
        catch
        {
            __result = default;
            return false;
        }
    }
}