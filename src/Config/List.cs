using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using MorePiles.Constructor;
using Vintagestory.API.Common;

namespace MorePiles.List
{
  [JsonObject]
	public class MorePilesConfig : ModSystem, IEnumerable<KeyValuePair<string, Part>>
	{
		public static MorePilesConfig Loaded { get; set; } = new MorePilesConfig();
		private const string w = "NEED TO WAIT FOR A FIX IN VANILLA";

		public Part AngledGear { get; set; } = new Part(true, 8, "Min. 4");
		public Part Arrow { get; set; } = new Part(true, 64, "Min. 32");
		public Part Axle { get; set; } = new Part(true, 16, " Min. 16 or just 4|8");
		public Part BambooStakes { get; set; } = new Part(true, 32, "Min. 32");
		public Part Beeswax { get; set; } = new Part(true, 32, "Min. 8");
		public Part Bone { get; set; } = new Part(true, 64, "Min. 64 or 32");
		public Part ChuteSection { get; set; } = new Part(true, 64, "Min. 8");
		public Part Cloth { get; set; } = new Part(true, 32, "Min. 12");
		public Part CookingPotBurnt { get; set; } = new Part(false, 12, $"{w}");
		public Part FenceDryStone { get; set; } = new Part(true, 64, "Min. 8");
		public Part FenceGateWooden { get; set; } = new Part(true, 64, "Min. 8");
		public Part FenceWooden { get; set; } = new Part(true, 64, "Min. 8");
		public Part FlaxFibers { get; set; } = new Part(true, 64, "Min. 16");
		public Part FlaxTwine { get; set; } = new Part(true, 32, "Min. 8");
		public Part FlowerpotBurnt { get; set; } = new Part(false, 8, $"{w}");
		public Part Henbox { get; set; } = new Part(true, 64, "Min. 4");
		public Part Honeycomb { get; set; } = new Part(true, 8, "Min. 4");
		public Part IronBloom { get; set; } = new Part(true, 64, "Min. 4");
		public Part IronFence { get; set; } = new Part(true, 64, "Min. 16");
		public Part Ladder { get; set; } = new Part(true, 64, "Min. 8");
		public Part MetalChain { get; set; } = new Part(true, 8, "Min. 8");
		public Part MetalLamellae { get; set; } = new Part(true, 8, "Min. 8");
		public Part MetalScales { get; set; } = new Part(true, 8, "Min. 8");
		public Part Painting { get; set; } = new Part(true, 64, "Min. 16");
		public Part Poultice { get; set; } = new Part(false, 64, $"{w}");
		public Part Sail { get; set; } = new Part(true, 8, "Min. 8 or just 4");
		public Part Sign { get; set; } = new Part(true, 64, "Min. 8");
		public Part Stick { get; set; } = new Part(true, 64, "Min. 64 or just 32");
		public Part Stone { get; set; } = new Part(false, 64, $"Min. 32, {w}");
		public Part Toolrack { get; set; } = new Part(true, 64, "Min. 16");
		public Part Torchholder { get; set; } = new Part(true, 8, "Min. 8");
		public Part Trapdoor { get; set; } = new Part(true, 64, "Min. 8");
		public Part TroughLarge { get; set; } = new Part(true, 64, "Min. 4");
		public Part TroughSmall { get; set; } = new Part(true, 64, "Min. 4");

		private static readonly PropertyInfo[] propertyInfos = typeof(MorePilesConfig).GetProperties()
			.Where(propertyInfo => propertyInfo.PropertyType == typeof(Part)).ToArray();

		public IEnumerator<KeyValuePair<string, Part>> GetEnumerator()
		{
			return propertyInfos.Select(propertyInfo => new KeyValuePair<string, Part>(propertyInfo.Name, (Part)propertyInfo.GetValue(this))).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}