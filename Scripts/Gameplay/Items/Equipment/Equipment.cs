using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

public class Equipment : ItemEntry, IEquippable
{
    public Equipment() : this("Equipment", "Desc", new Money(), 10, ["prop"], []) { }
    public Equipment(string name, string description, Money price, int weight,
    List<string> properties, Dictionary<ProficiencyType, RollType> proficiencyModifiers) :
     base(name, description, price, weight)
    {
        Properties = properties;
        ProficiencyModifiers = proficiencyModifiers;
    }

    [XmlArray]
    [XmlArrayItem("Properties")]
    public List<string> Properties { get; set; }
    [XmlArray("ProficiencyModifiers")]
    [XmlArrayItem("Modifier")]
    public List<ProficiencyModifier> ProficiencyModifiersSerializable
    {
        get;
        set;
    }

    [XmlIgnore]
    public Dictionary<ProficiencyType, RollType> ProficiencyModifiers { get; set; }
        = new();

    // Helper class for serialization
    public class ProficiencyModifier
    {
        [XmlElement("ProficiencyType")]
        public ProficiencyType Type { get; set; }

        [XmlElement("RollType")]
        public RollType RollType { get; set; }
    }

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
