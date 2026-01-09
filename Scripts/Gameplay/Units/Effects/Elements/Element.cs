using System;
using Godot;

[GlobalClass]
public partial class Element : BaseEffect
{

    public ElementType Type { get; set; }
    public int CurrentStacks { get; set; }
    public int DurationLeft { get; set; }

    public override void ApplyEffect()
    {
        throw new NotImplementedException();
    }

    public override BaseEffect Finish()
    {
        throw new NotImplementedException();
    }

    public override int GetDurationLeft()
    {
        throw new NotImplementedException();
    }

    public override void Tick()
    {
        throw new NotImplementedException();
    }
}
