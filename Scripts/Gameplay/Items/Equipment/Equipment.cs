
using Godot;
using Godot.Collections;

[GlobalClass]
public partial class Equipment : ItemEntry, IEquippable
{
    public Equipment() : this("Equipment", "Desc", new Money(), 10, ["prop"], []) { }
    public Equipment(string name, string description, Money price, int weight,
    Array<string> properties, Dictionary<SkillTypes, RollType> proficiencyModifiers) :
     base(name, description, price, weight)
    {
        Properties = properties;
        SkillModifiers = proficiencyModifiers;
    }


    [Export] public Stats ItemStats;
    [Export] public Array<string> Properties { get; set; }
    [Export] public Dictionary<SkillTypes, RollType> SkillModifiers { get; set; } = new();




    //TODO: Implement IEquippable
    public void Equip()
    {
        throw new System.NotImplementedException();
    }

    public void Unequip()
    {
        throw new System.NotImplementedException();
    }
}
