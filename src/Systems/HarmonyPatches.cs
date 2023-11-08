using HarmonyLib;
using Vintagestory.API.Common;
using Vintagestory.GameContent;

namespace MorePiles;

public class HarmonyPatches : ModSystem
{
    public const string HarmonyID = "craluminum2413.morepiles";
    public static Harmony HarmonyInstance { get; set; } = new Harmony(HarmonyID);

    public override void StartPre(ICoreAPI api)
    {
        base.StartPre(api);
        HarmonyInstance.Patch(original: typeof(BlockGroundStorage).GetMethod(nameof(BlockGroundStorage.OnLoaded)), postfix: typeof(BlockGroundStorage_Init_Patch).GetMethod(nameof(BlockGroundStorage_Init_Patch.Postfix)));
        HarmonyInstance.Patch(original: typeof(ItemRope).GetMethod(nameof(ItemRope.OnHeldInteractStart)), prefix: typeof(ItemRope_OnHeldInteractStart_Patch).GetMethod(nameof(ItemRope_OnHeldInteractStart_Patch.Prefix)));
        HarmonyInstance.Patch(original: typeof(Block).GetMethod(nameof(Block.CanPlaceBlock)), prefix: typeof(Block_CanPlaceBlock_Patch).GetMethod(nameof(Block_CanPlaceBlock_Patch.Prefix)));
    }

    public override void Dispose()
    {
        HarmonyInstance.Unpatch(original: typeof(BlockGroundStorage).GetMethod(nameof(BlockGroundStorage.OnLoaded)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(ItemRope).GetMethod(nameof(ItemRope.OnHeldInteractStart)), type: HarmonyPatchType.All, HarmonyID);
        HarmonyInstance.Unpatch(original: typeof(Block).GetMethod(nameof(Block.CanPlaceBlock)), type: HarmonyPatchType.All, HarmonyID);
        base.Dispose();
    }
}