using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using Newtonsoft.Json;
using MorePiles.Constructor;

namespace MorePiles.List
{
  [JsonObject]
	public class MorePilesConfig : IEnumerable<KeyValuePair<string, Pile>>
	{
		public static MorePilesConfig Loaded { get; set; } = new MorePilesConfig();
		private const string w = "NEED TO WAIT FOR A FIX IN VANILLA";

		public Pile AngledGear { get; set; } = new Pile(true, 8, "Min. 4");
		public Pile Arrow { get; set; } = new Pile(true, 64, "Min. 32");
		public Pile Axle { get; set; } = new Pile(true, 16, " Min. 16 or just 4|8");
		public Pile BambooStakes { get; set; } = new Pile(true, 32, "Min. 32");
		public Pile Beeswax { get; set; } = new Pile(true, 32, "Min. 8");
		public Pile Bone { get; set; } = new Pile(true, 64, "Min. 64 or 32");
		public Pile ChuteSection { get; set; } = new Pile(true, 64, "Min. 8");
		public Pile Cloth { get; set; } = new Pile(true, 32, "Min. 12");
		public Pile CookingPotBurnt { get; set; } = new Pile(false, 12, $"{w}");
		public Pile FenceDryStone { get; set; } = new Pile(true, 64, "Min. 8");
		public Pile FenceGateWooden { get; set; } = new Pile(true, 64, "Min. 8");
		public Pile FenceWooden { get; set; } = new Pile(true, 64, "Min. 8");
		public Pile FlaxFibers { get; set; } = new Pile(true, 64, "Min. 16");
		public Pile FlaxTwine { get; set; } = new Pile(true, 32, "Min. 8");
		public Pile FlowerpotBurnt { get; set; } = new Pile(false, 8, $"{w}");
		public Pile Henbox { get; set; } = new Pile(true, 64, "Min. 4");
		public Pile Honeycomb { get; set; } = new Pile(true, 8, "Min. 4");
		public Pile IronBloom { get; set; } = new Pile(true, 64, "Min. 4");
		public Pile IronFence { get; set; } = new Pile(true, 64, "Min. 16");
		public Pile Ladder { get; set; } = new Pile(true, 64, "Min. 8");
		public Pile MetalChain { get; set; } = new Pile(true, 8, "Min. 8");
		public Pile MetalLamellae { get; set; } = new Pile(true, 8, "Min. 8");
		public Pile MetalScales { get; set; } = new Pile(true, 8, "Min. 8");
		public Pile Painting { get; set; } = new Pile(true, 64, "Min. 16");
		public Pile Poultice { get; set; } = new Pile(false, 64, $"{w}");
		public Pile Sail { get; set; } = new Pile(true, 8, "Min. 8 or just 4");
		public Pile Sign { get; set; } = new Pile(true, 64, "Min. 8");
		public Pile Stick { get; set; } = new Pile(true, 64, "Min. 64 or just 32");
		public Pile Stone { get; set; } = new Pile(false, 64, $"Min. 32, {w}");
		public Pile Toolrack { get; set; } = new Pile(true, 64, "Min. 16");
		public Pile Torchholder { get; set; } = new Pile(true, 8, "Min. 8");
		public Pile Trapdoor { get; set; } = new Pile(true, 64, "Min. 8");
		public Pile TroughLarge { get; set; } = new Pile(true, 64, "Min. 4");
		public Pile TroughSmall { get; set; } = new Pile(true, 64, "Min. 4");

		private static readonly PropertyInfo[] propertyInfos = typeof(MorePilesConfig).GetProperties()
			.Where(propertyInfo => propertyInfo.PropertyType == typeof(Pile)).ToArray();

		public IEnumerator<KeyValuePair<string, Pile>> GetEnumerator()
		{
			return propertyInfos.Select(propertyInfo => new KeyValuePair<string, Pile>(propertyInfo.Name, (Pile)propertyInfo.GetValue(this))).GetEnumerator();
		}

		IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
	}
}