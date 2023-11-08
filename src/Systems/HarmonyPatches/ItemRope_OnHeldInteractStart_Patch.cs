using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;

namespace MorePiles;

public static class ItemRope_OnHeldInteractStart_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(ItemRope), nameof(ItemRope.OnHeldInteractStart))]
    public static bool Prefix(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
    {
        if (blockSel == null) return true;

        var bh = slot.Itemstack.Collectible.GetBehavior<CollectibleBehaviorGroundStorable>();
        var isUpFace = blockSel?.Face == BlockFacing.UP;
        var be = byEntity?.World?.BlockAccessor.GetBlockEntity(blockSel?.Position);

        if (bh != null && (be is BlockEntityGroundStorage || isUpFace))
        {
            var handHandling = EnumHandling.PassThrough;
            bh.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handling, ref handHandling);
            return false;
        }

        return true;
    }
}