using Godot;

[GlobalClass]
public abstract partial class BaseEffect : Resource
{
    [Export] public int Duration { get; set; }

    public Unit AppliedTo { get; set; }
    public abstract void ApplyEffect();
    public abstract void Tick();
    public abstract int GetDurationLeft();
    public abstract BaseEffect Finish();


}
