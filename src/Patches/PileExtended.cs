using Vintagestory.API.Common;
using Vintagestory.API.MathTools;
using Vintagestory.GameContent;

namespace MorePiles;

public class PileExtended
{
    public bool Enabled { get; }

    public GroundStorageProperties GroundStorageProps { get; }

    public PileExtended(string key, CollectibleObject obj, ICoreAPI api)
    {
        Enabled = api.World.Config.GetBool($"morepiles-{key}-enabled");

        // var _CbScaleYByLayer = obj.GetCbScale(key);
        // var _CollisionBox = obj.GetCollisionBox(key);
        var _upSolid = api.World.Config.GetBool($"morepiles-{key}-upsolid");
        var _sprintKey = obj.GetSprintKey(key);
        var _bulkTransferQuantity = api.World.Config.GetInt($"morepiles-{key}-bulktransferquantity");
        var _transferQuantity = api.World.Config.GetInt($"morepiles-{key}-transferquantity");
        var _stackingCapacity = api.World.Config.GetInt($"morepiles-{key}-stackingcapacity");
        var _stackingModel = obj.GetModel(key);
        var _modelItemsToStackSizeRatio = (float)api.GetShapeElementCount(_stackingModel.ToString()) / _stackingCapacity;
        // var _placeRemoveSound = obj.GetSound(key);

        GroundStorageProps = new()
        {
            Layout = EnumGroundStorageLayout.Stacking,
            CbScaleYByLayer = default,
            CollisionBox = default,
            UpSolid = _upSolid,
            SprintKey = _sprintKey,
            BulkTransferQuantity = _bulkTransferQuantity,
            TransferQuantity = _transferQuantity,
            StackingCapacity = _stackingCapacity,
            StackingModel = _stackingModel,
            ModelItemsToStackSizeRatio = _modelItemsToStackSizeRatio,
            PlaceRemoveSound = default
        };
    }
}