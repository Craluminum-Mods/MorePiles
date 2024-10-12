using HarmonyLib;
using Vintagestory.GameContent;

namespace MorePiles;

[HarmonyPatch(typeof(BlockGroundStorage), nameof(BlockGroundStorage.OnLoaded))]
public static class BlockGroundStorage_Init_Patch
{
    public static void Postfix(BlockGroundStorage __instance)
    {
        __instance.PlacedPriorityInteract = true;
    }
}