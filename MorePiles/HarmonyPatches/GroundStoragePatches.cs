using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MorePiles;

[HarmonyPatch]
public static class GroundStoragePatches
{
    [HarmonyPatch(typeof(ItemRope), nameof(ItemRope.OnHeldInteractStart))]
    public static class FixRopePilePlacement
    {
        [HarmonyPrefix]
        public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
            => slot.TryFixGroundStoragePlacement(byEntity, blockSel, entitySel, firstEvent, ref handling);
    }

    [HarmonyPatch(typeof(BlockBehaviorDecor), nameof(BlockBehaviorDecor.TryPlaceBlock))]
    public static class FixDecorPilePlacement
    {
        [HarmonyPrefix]
        public static bool Prefix(ref bool __result, IPlayer byPlayer, BlockSelection blockSel)
        {
            ItemSlot activeSlot = byPlayer?.InventoryManager?.ActiveHotbarSlot;
            EnumHandHandling handHandling = EnumHandHandling.NotHandled;
            bool result = activeSlot.TryFixGroundStoragePlacement(byPlayer?.Entity, blockSel, byPlayer?.CurrentEntitySelection, true, ref handHandling);
            __result = result;
            return result;
        }
    }

    [HarmonyPatch(typeof(Block), nameof(Block.CanPlaceBlock))]
    public static class FixBlockPlacement
    {
        public static bool Prefix(ref bool __result, IPlayer byPlayer, BlockSelection blockSel)
        {
            ItemSlot activeSlot = byPlayer?.InventoryManager?.ActiveHotbarSlot;
            EnumHandHandling handHandling = EnumHandHandling.NotHandled;
            bool result = activeSlot.TryFixGroundStoragePlacement(byPlayer?.Entity, blockSel, byPlayer?.CurrentEntitySelection, true, ref handHandling);
            __result = result;
            return result;
        }
    }
}