using Godot;

public class HexLayout
{
    private HexLayout(float f0, float f1, float f2, float f3, float b0, float b1, float b2, float b3, float startingAngle)
    {
        this.F0 = f0;
        this.F1 = f1;
        this.F2 = f2;
        this.F3 = f3;
        this.B0 = b0;
        this.B1 = b1;
        this.B2 = b2;
        this.B3 = b3;
        this.StartingAngle = startingAngle;
    }

    public float F0 { get; init; }
    public float F1 { get; init; }
    public float F2 { get; init; }
    public float F3 { get; init; }
    public float B0 { get; init; }
    public float B1 { get; init; }
    public float B2 { get; init; }
    public float B3 { get; init; }
    public float StartingAngle { get; init; }
    public static readonly HexLayout Pointy = new(
        Mathf.Sqrt(3), Mathf.Sqrt(3) / 2f, 0f, 3f / 2f, Mathf.Sqrt(3) / 3f, -1f / 3f, 0f, 2f / 3f, 0.5f
    );
    public static readonly HexLayout Flat = new(
       3f / 2f, 0.0f, Mathf.Sqrt(3) / 2f, Mathf.Sqrt(3), 2f / 3f, 0f, -1f / 3f, Mathf.Sqrt(3) / 3f, 0f
    );
}