using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace MorePiles;

public static class CollectibleObjectExtensions
{
    public static void AppendBehavior(this CollectibleObject obj, object objectProperties)
    {
        obj.CollectibleBehaviors ??= Array.Empty<CollectibleBehavior>();

        CollectibleBehaviorGroundStorable instance = new CollectibleBehaviorGroundStorable(obj);
        instance.Initialize(new JsonObject(JToken.FromObject(objectProperties)));
        obj.CollectibleBehaviors = new CollectibleBehavior[] { instance }.Append(obj.CollectibleBehaviors);
    }

    public static void RemoveGroundStorableBehaviors(this CollectibleObject obj)
    {
        obj.CollectibleBehaviors ??= Array.Empty<CollectibleBehavior>();

        List<CollectibleBehavior> list = obj.CollectibleBehaviors.ToList();
        list.RemoveAll(x => x is CollectibleBehaviorGroundStorable);
        obj.CollectibleBehaviors = list.ToArray();
    }

    public static bool IsGroundStorable(this CollectibleObject obj) => obj.HasBehavior<CollectibleBehaviorGroundStorable>();

    public static void AddToCreativeInventory(this CollectibleObject obj)
    {
        if (obj.CreativeInventoryStacks != null)
        {
            for (int i = 0; i < obj.CreativeInventoryStacks.Length; i++)
            {
                if (obj.CreativeInventoryStacks[i].Tabs.Contains("groundstorable"))
                {
                    continue;
                }
                obj.CreativeInventoryStacks[i].Tabs = obj.CreativeInventoryStacks[i].Tabs.Append("groundstorable");
            }
            return;
        }
        if (obj.CreativeInventoryTabs != null && !obj.CreativeInventoryTabs.Contains("groundstorable"))
        {
            obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
        }
    }
}