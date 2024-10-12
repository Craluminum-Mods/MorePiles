using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;
using Vintagestory.API.MathTools;
using Vintagestory.API.Datastructures;

namespace MorePiles;

public static class Block_CanPlaceBlock_Patch
{
    [HarmonyPrefix]
    [HarmonyPatch(typeof(Block), nameof(Block.CanPlaceBlock))]
    public static bool Prefix(ref bool __result, IWorldAccessor world, IPlayer byPlayer, BlockSelection blockSel)
    {
        if (blockSel == null || world == null || byPlayer == null)
        {
            return true;
        }

        ItemSlot activeSlot = byPlayer.InventoryManager?.ActiveHotbarSlot;
        if (activeSlot?.Empty != false)
        {
            return true;
        }

        CollectibleBehaviorGroundStorable bh = activeSlot?.Itemstack.Collectible.GetBehavior<CollectibleBehaviorGroundStorable>();
        if (bh == null)
        {
            return true;
        }

        bool isGroundStorage = blockSel.Block is BlockGroundStorage;
        BlockEntityGroundStorage begs = world.BlockAccessor.GetBlockEntity(blockSel.Position) as BlockEntityGroundStorage;

        // breaks creating of charcoal firepit
        // if ((isGroundStorage && !begs.CanCreatePitKiln()) || (isGroundStorage && BlockFacing.ALLFACES.Contains(blockSel.Face)))
        if (isGroundStorage && !begs.CanCreatePitKiln())
        {
            __result = false;
            return false;
        }

        bool needSprintKey = bh.StorageProps.SprintKey;
        bool shiftKey = byPlayer.Entity.Controls.ShiftKey;
        bool ctrlKey = byPlayer.Entity.Controls.CtrlKey;

        if (blockSel.Face != BlockFacing.UP)
        {
            return true;
        }

        JsonObject attributes = activeSlot.Itemstack.Collectible.Attributes;
        if (attributes == null)
        {
            return true;
        }

        bool isKnappable = attributes["knappable"].AsBool();
        bool isItemStone = activeSlot.Itemstack.Collectible is ItemStone;
        bool isItemTreeSeed = activeSlot.Itemstack.Collectible is ItemTreeSeed;

        if (shiftKey)
        {
            if (needSprintKey && !ctrlKey)
            {
                return true;
            }
            else if (needSprintKey && ctrlKey && isKnappable)
            {
                __result = false;
                return false;
            }
            else if (isKnappable || isItemStone || isItemTreeSeed)
            {
                return true;
            }
            else
            {
                __result = false;
                return false;
            }
        }

        return true;
    }
}