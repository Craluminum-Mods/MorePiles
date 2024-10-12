using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace MorePiles;

public static class GroundStorageExtensions
{
    public static bool CanCreatePitKiln(this BlockEntityGroundStorage begs) => begs?.OnTryCreateKiln() != false;

    public static bool CanCreateCharcoalFirepit(this BlockEntityGroundStorage begs, ItemSlot slot, BlockSelection blockSel)
    {
        return blockSel.Face == BlockFacing.UP && slot.Itemstack.Collectible is ItemDryGrass
                        && begs?.Inventory[3]?.Empty == true
                        && begs?.Inventory[2]?.Empty == true
                        && begs?.Inventory[1]?.Empty == true
                        && begs?.Inventory[0]?.Itemstack?.Collectible is ItemFirewood;
    }
}