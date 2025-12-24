using System.Collections.Generic;
using System.Xml.Serialization;
public class Armor : Equipment
{
    public Armor() : this("Armor", "Desc", new Money(gold: 10), 10, ["something"], [], 13) { }
    public Armor(string name, string description, Money price, int weight, List<string> properties, Dictionary<ProficiencyType, RollType> proficiencyModifiers,
    int armorClass) :
     base(name, description, price, weight, properties, proficiencyModifiers)
    {
        ArmorClass = armorClass;
    }

    [XmlElement]
    public int ArmorClass { get; set; }

}