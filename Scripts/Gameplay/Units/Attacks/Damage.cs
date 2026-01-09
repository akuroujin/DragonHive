using System.Xml.Serialization;
using Godot;
[GlobalClass]
public partial class Damage : Resource, IDamage
{
    public Damage() : this(1, DamageTypes.Slashing) { }
    public Damage(int damage, DamageTypes damageType)
    {
        DamageBonus = damage;
        DamageType = damageType;

    }
    public Damage(int diceAmount, DiceTypes diceType, int damageBonus, DamageTypes damageType)
    {
        DiceAmount = diceAmount;
        this.DiceType = diceType;
        DamageBonus = damageBonus;
        this.DamageType = damageType;
    }

    [Export]
    public int DiceAmount { get; set; } = 0;
    [Export]
    public DiceTypes DiceType { get; set; } = DiceTypes.FLAT;
    [Export]
    public int DamageBonus { get; set; } = 0;
    [Export]
    public DamageTypes DamageType { get; set; }



    public int GetDamage()
    {
        return Dice.Roll(DiceType, DiceAmount) + DamageBonus;
    }
}
