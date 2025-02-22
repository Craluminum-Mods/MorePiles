using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MorePiles;

public class GroundStoragePropertiesExtended : GroundStorageProperties
{
    public JsonObject MorePilesProperties;

    public GroundStorageProperties Convert()
    {
        return new GroundStorageProperties()
        {
            Layout = EnumGroundStorageLayout.Stacking,
            CtrlKey = CtrlKey,
            UpSolid = UpSolid,
            BulkTransferQuantity = BulkTransferQuantity,
            TransferQuantity = TransferQuantity,
            StackingCapacity = StackingCapacity,
            PlaceRemoveSound = PlaceRemoveSound,
            StackingModel = StackingModel,
            CbScaleYByLayer = CbScaleYByLayer,
            CollisionBox = CollisionBox,
            ModelItemsToStackSizeRatio = ModelItemsToStackSizeRatio
        };
    }
}