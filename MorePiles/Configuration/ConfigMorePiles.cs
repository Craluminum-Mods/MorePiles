using Newtonsoft.Json;
using System.Collections.Generic;
using Vintagestory.API.Common;
using Vintagestory.API.Util;

namespace MorePiles.Configuration;

public class ConfigMorePiles : IModConfig
{
    [JsonProperty(Order = 1)]
    public bool AutoFill { get; set; } = true;

    [JsonProperty(Order = 2)]
    public Dictionary<string, DataPile> ItemPiles { get; set; } = new();

    [JsonProperty(Order = 3)]
    public Dictionary<string, DataPile> BlockPiles { get; set; } = new();

    public ConfigMorePiles(ICoreAPI api, ConfigMorePiles previousConfig = null)
    {
        if (previousConfig != null)
        {
            AutoFill = previousConfig.AutoFill;

            ItemPiles.AddRange(previousConfig.ItemPiles);
            BlockPiles.AddRange(previousConfig.BlockPiles);
        }

        if (api != null && AutoFill)
        {
            FillDefault(api);
        }
    }

    public void FillDefault(ICoreAPI api)
    {
        Core core = Core.GetInstance(api);

        ItemPiles.AddRange(core.DefaultItemPiles);
        BlockPiles.AddRange(core.DefaultBlockPiles);
    }
}