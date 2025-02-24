using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MorePiles;

[HarmonyPatch(typeof(BlockBehaviorDecor), nameof(BlockBehaviorDecor.TryPlaceBlock))]
public static class FixDecorPilePlacementPatch
{
    [HarmonyPrefix]
    public static bool Prefix(Block __instance, ref bool __result, IWorldAccessor world, IPlayer byPlayer, ItemStack itemstack, BlockSelection blockSel, ref EnumHandling handling, ref string failureCode)
    {
        if (blockSel == null || world == null || byPlayer == null)
        {
            return true;
        }

        bool pressedCtrlKey = byPlayer.Entity.Controls.CtrlKey;
        ItemSlot activeSlot = byPlayer.InventoryManager?.ActiveHotbarSlot;
        CollectibleBehaviorGroundStorable behavior = activeSlot?.GetGroundStorableBehavior();
        bool requiresCtrlKey = behavior?.StorageProps.CtrlKey == true;

        if (behavior == null || !behavior.CanFixPlacement() || (requiresCtrlKey && !pressedCtrlKey))
        {
            return true;
        }

        EnumHandHandling handHandling = EnumHandHandling.NotHandled;

        behavior.OnHeldInteractStart(activeSlot, byPlayer.Entity, blockSel, null, true, ref handHandling, ref handling);

        __result = false;
        return false;
    }
}