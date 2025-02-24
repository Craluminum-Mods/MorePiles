using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MorePiles;

public class GroundStoragePropertiesExtended : GroundStorageProperties
{
    [JsonProperty]
    [JsonConverter(typeof(JsonAttributesConverter))]
    public JsonObject MorePilesProperties;

    public void EnsurePropertiesNotNull()
    {
        MorePilesProperties ??= new JsonObject(new JObject());
    }

    public new GroundStoragePropertiesExtended Clone()
    {
        return new GroundStoragePropertiesExtended
        {
            MorePilesProperties = MorePilesProperties?.Clone(),
            Layout = Layout,
            WallOffY = WallOffY,
            PlaceRemoveSound = PlaceRemoveSound,
            RandomizeSoundPitch = RandomizeSoundPitch,
            StackingCapacity = StackingCapacity,
            StackingModel = StackingModel?.Clone(),
            StackingTextures = StackingTextures?.ToDictionary(x => x.Key, x => x.Value.Clone()),
            MaxStackingHeight = MaxStackingHeight,
            TransferQuantity = TransferQuantity,
            BulkTransferQuantity = BulkTransferQuantity,
            CollisionBox = CollisionBox,
            SelectionBox = SelectionBox,
            CbScaleYByLayer = CbScaleYByLayer,
            MaxFireable = MaxFireable,
            CtrlKey = CtrlKey,
            UpSolid = UpSolid
        };
    }
}