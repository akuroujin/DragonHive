using Godot;

public partial class StatusEffect : BaseEffect
{
    public StatusEffect(string name, int duration, bool isPermanent, Unit appliedTo)
    {
        Name = name;
        Duration = duration;
        IsPermanent = isPermanent;
        AppliedTo = appliedTo;
    }

    [Export] public string Name { get; set; }
    [Export] public bool IsPermanent { get; set; }

    public override void ApplyEffect()
    {
        throw new System.NotImplementedException();
    }

    public override BaseEffect Finish()
    {
        throw new System.NotImplementedException();
    }

    public override int GetDurationLeft()
    {
        throw new System.NotImplementedException();
    }

    public override void Tick()
    {
        throw new System.NotImplementedException();
    }
}
