namespace MorePiles.Constructor
{
  public class Pile
	{
		public bool Enabled { get; set; }
		public int StackingCapacity { get; set; }
		public int Default { get; set; }
		public string Available { get; set; } = "";

    public Pile(bool enabled, int stackingCapacity, string info)
    {
			Enabled = enabled;
			StackingCapacity = stackingCapacity;
			Default = stackingCapacity;
			Available = info;
    }
		public Pile(bool enabled, int stackingCapacity)
    {
			Enabled = enabled;
			StackingCapacity = stackingCapacity;
			Default = stackingCapacity;
    }
	}
}