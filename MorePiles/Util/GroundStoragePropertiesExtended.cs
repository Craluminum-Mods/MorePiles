using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
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
}