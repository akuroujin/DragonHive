using System;
using Godot;

[GlobalClass]
public partial class Buff : BaseEffect
{
    public Buff(BuffTypes type, int duration, bool isDebuff, int amount, Unit appliedTo)
    {
        Type = type;
        Duration = duration;
        this.isDebuff = isDebuff;
        Amount = amount;
        this.AppliedTo = appliedTo;
    }

    public BuffTypes Type { get; init; }
    public bool isDebuff { get; init; }
    public int Amount { get; init; }

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
