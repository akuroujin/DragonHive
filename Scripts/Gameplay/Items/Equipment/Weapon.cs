using Godot;
using Godot.Collections;

[GlobalClass]
public partial class Weapon : Equipment
{
    public Weapon(string name, string description, Money price, int weight, Array<string> properties, Dictionary<SkillTypes, RollType> proficiencyModifiers,
    Array<Attack> attacks)
    : base(name, description, price, weight, properties, proficiencyModifiers)
    {
        Attacks = attacks;
    }
    [Export] public Array<Attack> Attacks { get; set; }
}