using System.Reflection;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;
using System.Linq;

namespace MorePiles;

public class HarmonyPatches : ModSystem
{
    public const string HarmonyID = "craluminum2413.morepiles";

    public override void StartPre(ICoreAPI api)
    {
        base.StartPre(api);
        new Harmony(HarmonyID).PatchAll(Assembly.GetExecutingAssembly());
    }

    public override void Dispose()
    {
        new Harmony(HarmonyID).UnpatchAll();
        base.Dispose();
    }

    [HarmonyPatch]
    public static class Patches
    {
        [HarmonyPrefix]
        [HarmonyPatch(typeof(ItemRope), nameof(ItemRope.OnHeldInteractStart))]
        public static bool ItemRope_OnHeldInteractStart_Patch(ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handling)
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

        [HarmonyPrefix]
        [HarmonyPatch(typeof(Block), nameof(Block.CanPlaceBlock))]
        public static bool Block_CanPlaceBlock_Patch(ref bool __result, IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel, ref string failureCode)
        {
            if (blockSel == null || world == null || byPlayer?.Entity.Controls.ShiftKey != true) return true;

            var activeSlot = byPlayer?.InventoryManager?.ActiveHotbarSlot;
            if (activeSlot?.Empty != false) return true;

            var bh = activeSlot?.Itemstack?.Collectible?.GetBehavior<CollectibleBehaviorGroundStorable>();
            if (bh is not null)
            {
                var isGroundStorage = blockSel.Block is BlockGroundStorage;

                if ((isGroundStorage && blockSel.Face == BlockFacing.UP)
                || (isGroundStorage && BlockFacing.HORIZONTALS.Contains(blockSel.Face))
                || blockSel.Face == BlockFacing.UP)
                {
                    __result = false;
                    return false;
                }
            }

            return true;
        }
    }
}