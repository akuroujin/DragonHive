using Godot;
using Godot.Collections;
[GlobalClass]
public partial class Armor : Equipment
{
    public Armor(string name, string description, Money price, int weight, Array<string> properties, Dictionary<SkillTypes, RollType> proficiencyModifiers,
    int armorClass) :
     base(name, description, price, weight, properties, proficiencyModifiers)
    {
        ArmorClass = armorClass;
    }

    [Export]
    public int ArmorClass { get; set; }
    [Export]
    public Array<Attack> Actions { get; set; }

}