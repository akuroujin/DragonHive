using System.Collections.Generic;

public class Weapon : Equipment
{
    public Weapon(string name, string description, Money price, int weight, int amount, List<string> properties, Dictionary<ProficiencyType, RollType> proficiencyModifiers,
    List<Attack> attacks)
    : base(name, description, price, weight, amount, properties, proficiencyModifiers)
    {
        Attacks = attacks;
    }

    public List<Attack> Attacks { get; set; }
}