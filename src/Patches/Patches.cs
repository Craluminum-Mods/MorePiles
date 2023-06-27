using Newtonsoft.Json.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.MathTools;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace MorePiles
{
    public class Pile
    {
        public bool Enabled;
        public bool UpSolid;
        public int BulkTransferQuantity;
        public int TransferQuantity;
        public int StackingCapacity;
    }

    public static class Patches
    {
        private static void AppendBehavior(CollectibleObject collobj, object props, CollectibleBehavior instance)
        {
            var properties = new JsonObject(JToken.FromObject(props));
            instance.Initialize(properties);
            collobj.CollectibleBehaviors = collobj.CollectibleBehaviors.Append(instance);
        }

        public static void AppendBehaviors(this ICoreAPI api)
        {
            foreach (var obj in api.World.Collectibles)
            {
                if (obj.Code == null) continue;
                if (obj.Id == 0) continue;
                if (obj.HasBehavior<CollectibleBehaviorGroundStorable>()) continue;

                #region arrow
                if (obj.WildCardMatch("arrow-*"))
                {
                    const string key = "arrow";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)16 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.0625f, 1),
                        ModelItemsToStackSizeRatio = 448 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/arrowpile_32"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/stickplace"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion arrow
                #region bamboostakes
                if (obj.WildCardMatch("bamboostakes"))
                {
                    const string key = "bamboostakes";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.344f, 0, 0.344f, 0.656f, 0.125f, 0.656f),
                        ModelItemsToStackSizeRatio = 32 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/bamboostakespile_32"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/stickplace"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion bamboostakes
                #region beeswax
                if (obj.WildCardMatch("beeswax"))
                {
                    const string key = "beeswax";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.2941f, 0, 0.2941f, 0.75f, 0.125f, 0.75f),
                        ModelItemsToStackSizeRatio = 640 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/beeswaxpile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/effect/squish1"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion beeswax
                #region bone
                if (obj.WildCardMatch("bone"))
                {
                    const string key = "bone";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)16 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.0625f, 1),
                        ModelItemsToStackSizeRatio = 320 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/bonepile_64"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/ceramicplace"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion bone
                #region chutesection
                if (obj.WildCardMatch("chutesection-*"))
                {
                    const string key = "chutesection";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)20 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.05f, 1),
                        ModelItemsToStackSizeRatio = 256 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/chutesectionpile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/chute"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion chutesection
                #region cloth
                if (obj.WildCardMatch("cloth-*"))
                {
                    const string key = "cloth";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)49.4062 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.02f, 1),
                        ModelItemsToStackSizeRatio = 128 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/clothpile_12"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/cloth"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion cloth
                #region flaxfibers
                if (obj.WildCardMatch("flaxfibers"))
                {
                    const string key = "flaxfibers";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)16 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.0625f, 1),
                        ModelItemsToStackSizeRatio = 288 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/flaxfiberspile_16"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/cloth"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion flaxfibers
                #region flaxtwine
                if (obj.WildCardMatch("flaxtwine"))
                {
                    const string key = "flaxtwine";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.1875f, 0, 0.1875f, 0.8125f, 0.125f, 0.8125f),
                        ModelItemsToStackSizeRatio = 96 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/flaxtwinepile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/cloth"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion flaxtwine
                #region metalchain
                if (obj.WildCardMatch("metalchain-*"))
                {
                    const string key = "metalchain";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.0315f, 0, 0.0315f, 0.9685f, 0.125f, 0.9685f),
                        ModelItemsToStackSizeRatio = 752 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/metalchainpile_16"),
                        PlaceRemoveSound = new AssetLocation("sounds/wearable/chain1"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion metalchain
                #region metallamellae
                if (obj.WildCardMatch("metallamellae-*"))
                {
                    const string key = "metallamellae";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.0315f, 0, 0.0315f, 0.9685f, 0.125f, 0.9685f),
                        ModelItemsToStackSizeRatio = 32 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/metallamellaepile_32"),
                        PlaceRemoveSound = new AssetLocation("sounds/wearable/chain1"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion metallamellae
                #region metalscale
                if (obj.WildCardMatch("metalscale-*"))
                {
                    const string key = "metalscale";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.1875f, 0, 0.1875f, 0.8125f, 0.125f, 0.8125f),
                        ModelItemsToStackSizeRatio = 96 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/metalscalespile_32"),
                        PlaceRemoveSound = new AssetLocation("sounds/wearable/chain1"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion metalscale
                #region sail
                if (obj.WildCardMatch("sail"))
                {
                    const string key = "sail";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.125f, 1),
                        ModelItemsToStackSizeRatio = 72 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/sailpile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/cloth"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion sail
                #region stick
                if (obj.WildCardMatch("stick"))
                {
                    const string key = "stick";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)16 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.0625f, 1),
                        ModelItemsToStackSizeRatio = 192 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/stickpile_64"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/stickplace"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion stick

                #region angledgears
                if (obj.WildCardMatch("angledgears-s"))
                {
                    const string key = "angledgears";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.1875f, 0, 0.1875f, 0.8215f, 0.125f, 0.8215f),
                        ModelItemsToStackSizeRatio = 80 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/angledgearpile_4"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/stickplace"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion angledgears
                #region axle
                if (obj.WildCardMatch("woodenaxle-ud"))
                {
                    const string key = "axle";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)4 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.25f, 1),
                        ModelItemsToStackSizeRatio = 32 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/axlepile_16"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/stickplace"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion axle
                #region ironfence
                if (obj.WildCardMatch(new string[] { "ironfence-base-ew", "ironfence-top-ew" }))
                {
                    const string key = "ironfence";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)16 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.0625f, 0, 0.0625f, 0.9375f, 0.0625f, 0.9375f),
                        ModelItemsToStackSizeRatio = GetIronFenceRatio(obj, pile.StackingCapacity),
                        StackingModel = GetIronFenceModel(obj),
                        PlaceRemoveSound = new AssetLocation("sounds/block/ingot"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion ironfence
                #region torchholder
                if (obj.WildCardMatch("torchholder-*-empty-north"))
                {
                    const string key = "torchholder";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)4 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.188f, 0, 0.188f, 0.812f, 0.25f, 0.812f),
                        ModelItemsToStackSizeRatio = 32 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/torchholderpile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/ingot"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion torchholder
                #region drystonefence
                if (obj.WildCardMatch("drystonefence-*-ew-free"))
                {
                    const string key = "drystonefence";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)4 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.25f, 0, 0.25f, 0.75f, 0.25f, 0.75f),
                        ModelItemsToStackSizeRatio = 896 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/drystonefencepile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/loosestone1"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion drystonefence
                #region henbox
                if (obj.WildCardMatch("henbox-empty") || obj.WildCardMatch(new AssetLocation("vanvar", "henbox-*-empty")))
                {
                    const string key = "henbox";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)4 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.0625f, 0, 0.0625f, 0.9375f, 0.25f, 0.9375f),
                        ModelItemsToStackSizeRatio = 320 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/henboxpile_4"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/planks"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion henbox
                #region ladder
                if (obj.WildCardMatch(new string[] { "ladder-*-north" }))
                {
                    const string key = "ladder";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.125f, 0, 0.125f, 0.875f, 0.125f, 0.875f),
                        ModelItemsToStackSizeRatio = GetLadderRatio(obj, pile.StackingCapacity),
                        StackingModel = GetLadderModel(obj),
                        PlaceRemoveSound = new AssetLocation("sounds/block/planks"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion ladder
                #region sign
                if (obj.WildCardMatch("sign-ground-north") || obj.WildCardMatch(new AssetLocation("vanvar", "sign-*-ground-north")))
                {
                    const string key = "sign";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.125f, 0, 0.125f, 0.875f, 0.125f, 0.875f),
                        ModelItemsToStackSizeRatio = 320 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/signpile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/planks"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion sign
                #region toolrack
                if (obj.WildCardMatch("toolrack-north") || obj.WildCardMatch(new AssetLocation("vanvar", "toolrack-*-north")))
                {
                    const string key = "toolrack";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.1565f, 0, 0.1565f, 0.8435f, 0.125f, 0.8435f),
                        ModelItemsToStackSizeRatio = 128 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/toolrackpile_16"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/planks"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion toolrack
                #region trapdoor
                if (obj.WildCardMatch("trapdoor-closed-up-north") || obj.WildCardMatch(new AssetLocation("vanvar", "trapdoor-*-closed-up-north")))
                {
                    const string key = "trapdoor";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.125f, 0, 0.125f, 0.875f, 0.125f, 0.875f),
                        ModelItemsToStackSizeRatio = 112 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/trapdoorpile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/planks"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion trapdoor
                #region fence
                if (obj.WildCardMatch("woodenfence-*-ew-free"))
                {
                    const string key = "fence";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.125f, 0, 0.125f, 0.875f, 0.125f, 0.875f),
                        ModelItemsToStackSizeRatio = 320 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/woodenfencepile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/planks"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion fence
                #region fencegate
                if (obj.WildCardMatch("woodenfencegate-*-n-closed-left-free"))
                {
                    const string key = "fencegate";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0.125f, 0, 0.125f, 0.875f, 0.125f, 0.875f),
                        ModelItemsToStackSizeRatio = 256 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/woodenfencegatepile_8"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/planks"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion fencegate
                #region stone
                if (obj.WildCardMatch("stone-*") && obj is ItemStone)
                {
                    const string key = "stone";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.125f, 1),
                        ModelItemsToStackSizeRatio = 72 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/stonepile_72"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/loosestone"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion stone
                #region rope
                if (obj.Code.Equals(new AssetLocation("rope")))
                {
                    const string key = "rope";
                    if (!GetPile(api, key, out var pile).Enabled) continue;

                    var gsprops = new GroundStorageProperties()
                    {
                        Layout = EnumGroundStorageLayout.Stacking,
                        CbScaleYByLayer = (float)8 / pile.StackingCapacity,
                        CollisionBox = new Cuboidf(0, 0, 0, 1, 0.125f, 1),
                        ModelItemsToStackSizeRatio = 512 / pile.StackingCapacity,
                        StackingModel = new AssetLocation("morepiles:shapes/ropepile_32"),
                        PlaceRemoveSound = new AssetLocation("sounds/block/cloth"),
                        UpSolid = pile.UpSolid,
                        BulkTransferQuantity = pile.BulkTransferQuantity,
                        TransferQuantity = pile.TransferQuantity,
                        StackingCapacity = pile.StackingCapacity,
                    };
                    AppendBehavior(obj, gsprops, new CollectibleBehaviorGroundStorable(obj));
                    obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
                }
                #endregion rope
            }
        }

        private static Pile GetPile(ICoreAPI api, string key, out Pile pile)
        {
            pile = new()
            {
                Enabled = api.World.Config.GetBool($"morepiles-{key}-enabled"),
                UpSolid = api.World.Config.GetBool($"morepiles-{key}-upsolid"),
                BulkTransferQuantity = api.World.Config.GetInt($"morepiles-{key}-bulktransferquantity"),
                TransferQuantity = api.World.Config.GetInt($"morepiles-{key}-transferquantity"),
                StackingCapacity = api.World.Config.GetInt($"morepiles-{key}-stackingcapacity")
            };

            return pile;
        }

        private static float GetIronFenceRatio(CollectibleObject obj, int stackingCapacity) => obj.WildCardMatch("*-base-*")
            ? 112 / stackingCapacity
            : 160 / stackingCapacity;

        private static AssetLocation GetIronFenceModel(CollectibleObject obj) => obj.WildCardMatch("*-base-*")
            ? new AssetLocation("morepiles:shapes/ironfencepile-base")
            : new AssetLocation("morepiles:shapes/ironfencepile-top");

        private static float GetLadderRatio(CollectibleObject obj, int stackingCapacity) => obj.WildCardMatch("*-rope-*")
            ? 704 / stackingCapacity
            : 320 / stackingCapacity;

        private static AssetLocation GetLadderModel(CollectibleObject obj) => obj.WildCardMatch("*-rope-*")
            ? new AssetLocation("morepiles:shapes/ladderpile-rope_8")
            : new AssetLocation("morepiles:shapes/ladderpile-wood_8");
    }
}