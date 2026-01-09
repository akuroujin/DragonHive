using System.Xml.Serialization;
using Godot;

[GlobalClass]
public partial class Resistance : Resource
{
    public Resistance() : this(DamageTypes.Slashing) { }
    public Resistance(DamageTypes type, bool isImmunity = false)
    {
        Type = type;
        IsImmunity = isImmunity;
    }
    [Export]
    public DamageTypes Type { get; set; }
    [Export]
    public bool IsImmunity { get; set; }



    public int GetResistanceDamage(int damage, DamageTypes type)
    {
        if (type != Type)
            return damage;

        if (IsImmunity)
            return 0;

        return damage / 2;
    }
}
