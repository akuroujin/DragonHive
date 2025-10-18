using System.Xml.Serialization;

public class Resistance
{
    public Resistance() : this(DamageType.Slashing) { }
    public Resistance(DamageType type, bool isImmunity = false)
    {
        Type = type;
        IsImmunity = isImmunity;
    }
    [XmlElement]
    public DamageType Type { get; init; }
    [XmlElement]
    public bool IsImmunity { get; init; }



    public int GetResistanceDamage(int damage, DamageType type)
    {
        if (type != Type)
            return damage;

        if (IsImmunity)
            return 0;

        return damage / 2;
    }
}
