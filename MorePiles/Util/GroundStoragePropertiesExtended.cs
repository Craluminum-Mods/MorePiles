using Newtonsoft.Json;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.GameContent;

namespace MorePiles;

public class GroundStoragePropertiesExtended : GroundStorageProperties
{
    [JsonProperty]
    [JsonConverter(typeof(JsonAttributesConverter))]
    public JsonObject MorePilesProperties;
}