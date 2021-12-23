namespace MorePiles.Constructor
{
  public class Part
	{
		public bool Enabled { get; set; }
		public int StackingCapacity { get; set; }
		public int Default { get; set; }
		public string Available { get; set; } = "";

    public Part(bool enabled, int stackingCapacity, string info)
    {
			Enabled = enabled;
			StackingCapacity = stackingCapacity;
			Default = stackingCapacity;
			Available = info;
    }
		public Part(bool enabled, int stackingCapacity)
    {
			Enabled = enabled;
			StackingCapacity = stackingCapacity;
			Default = stackingCapacity;
    }
	}
}