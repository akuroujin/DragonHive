using System.Xml.Serialization;

public class Resistance
{
    [XmlElement]
    public DamageType Type { get; init; }
    [XmlElement]
    public bool IsImmunity { get; init; }

    public Resistance(DamageType type, bool isImmunity)
    {
        Type = type;
        IsImmunity = isImmunity;
    }

    public int GetResistanceDamage(int damage, DamageType type)
    {
        if (type != Type)
            return damage;

        if (IsImmunity)
            return 0;

        return damage / 2;
    }
}
