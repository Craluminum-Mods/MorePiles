using Vintagestory.API.MathTools;

namespace MorePiles;

/// <summary>
/// Copy paste of Cuboidf class
/// </summary>
public class CuboidfExtended
{
    public float X1 { get; set; }
    public float Y1 { get; set; }
    public float Z1 { get; set; }
    public float X2 { get; set; }
    public float Y2 { get; set; }
    public float Z2 { get; set; }

    public Cuboidf Convert() => new Cuboidf() { X1 = X1, Y1 = Y1, Z1 = Z1, X2 = X2, Y2 = Y2, Z2 = Z2 };
}
