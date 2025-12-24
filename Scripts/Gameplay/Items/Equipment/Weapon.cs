using System.Collections.Generic;

public class Weapon : Equipment
{
    public Weapon(string name, string description, Money price, int weight, List<string> properties, Dictionary<ProficiencyType, RollType> proficiencyModifiers,
    List<Attack> attacks)
    : base(name, description, price, weight, properties, proficiencyModifiers)
    {
        Attacks = attacks;
    }

    public List<Attack> Attacks { get; set; }
}