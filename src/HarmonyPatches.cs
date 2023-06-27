using System.Reflection;
using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;

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
    }
}