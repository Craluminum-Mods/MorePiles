using Newtonsoft.Json.Linq;
using System.Collections.Generic;
using System.Linq;
using Vintagestory.API.Common;
using Vintagestory.API.Datastructures;
using Vintagestory.API.Util;
using Vintagestory.GameContent;

namespace MorePiles;

public static class CollectibleObjectExtensions
{
    public static JsonObject GetProperties(this CollectibleBehavior behavior)
    {
        return new JsonObject(JToken.Parse(behavior.propertiesAtString));
    }

    public static bool CanFixPlacement(this CollectibleBehaviorGroundStorable behavior)
    {
        return behavior.GetProperties()?["MorePilesProperties"]?.IsTrue("FixPlacement") == true;
    }

    public static void AppendBehavior(this CollectibleObject obj, object objectProperties)
    {
        CollectibleBehaviorGroundStorable instance = new CollectibleBehaviorGroundStorable(obj);
        instance.Initialize(new JsonObject(JToken.FromObject(objectProperties)));
        obj.CollectibleBehaviors = new CollectibleBehavior[] { instance }.Append(obj.CollectibleBehaviors);
    }

    public static void RemoveGroundStorableBehaviors(this CollectibleObject obj)
    {
        List<CollectibleBehavior> list = obj.CollectibleBehaviors?.ToList();
        list?.RemoveAll(x => x is CollectibleBehaviorGroundStorable);
        obj.CollectibleBehaviors = list.ToArray();
    }

    public static void ResolveStackingTextures(this CollectibleObject obj, GroundStoragePropertiesExtended props)
    {
        if (props.StackingTextures == null)
        {
            return;
        }

        Dictionary<string, AssetLocation> stackingTextures = new Dictionary<string, AssetLocation>();

        foreach (KeyValuePair<string, AssetLocation> texture in props.StackingTextures)
        {
            KeyValuePair<string, AssetLocation> newTexture = texture;

            foreach (KeyValuePair<string, string> variant in obj.Variant)
            {
                newTexture.Value.Path = texture.Value.Path.Replace("{" + variant.Key + "}", variant.Value);
            }

            stackingTextures.Add(newTexture.Key, newTexture.Value);
        }

        props.StackingTextures = stackingTextures;
    }

    public static bool IsGroundStorable(this CollectibleObject obj) => obj.HasBehavior<CollectibleBehaviorGroundStorable>();
    public static CollectibleBehaviorGroundStorable GetGroundStorableBehavior(this ItemSlot slot) => slot?.Itemstack?.Collectible?.GetBehavior<CollectibleBehaviorGroundStorable>();

    public static void AddToCreativeInventory(this CollectibleObject obj)
    {
        if (obj.CreativeInventoryTabs?.Length > 0 && !obj.CreativeInventoryTabs.Contains("groundstorable"))
        {
            obj.CreativeInventoryTabs = obj.CreativeInventoryTabs.Append("groundstorable");
            return;
        }
        if (obj.CreativeInventoryStacks?.Length > 0)
        {
            for (int i = 0; i < obj.CreativeInventoryStacks.Length; i++)
            {
                if (obj.CreativeInventoryStacks[i].Tabs.Contains("groundstorable"))
                {
                    continue;
                }
                obj.CreativeInventoryStacks[i].Tabs = obj.CreativeInventoryStacks[i].Tabs.Append("groundstorable");
            }
        }
    }

    public static bool TryFixGroundStoragePlacement(this ItemSlot slot, EntityAgent byEntity, BlockSelection blockSel, EntitySelection entitySel, bool firstEvent, ref EnumHandHandling handHandling)
    {
        if (slot == null || blockSel == null || byEntity == null)
        {
            return true;
        }

        bool pressedCtrlKey = byEntity.Controls.CtrlKey;
        CollectibleBehaviorGroundStorable behavior = byEntity.ActiveHandItemSlot?.GetGroundStorableBehavior();
        bool requiresCtrlKey = behavior?.StorageProps.CtrlKey == true;

        if (behavior == null || !behavior.CanFixPlacement() || (requiresCtrlKey && !pressedCtrlKey))
        {
            return true;
        }

        EnumHandling _handling = EnumHandling.PassThrough;

        behavior.OnHeldInteractStart(slot, byEntity, blockSel, entitySel, firstEvent, ref handHandling, ref _handling);

        return false;
    }
}