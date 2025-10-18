using System.Collections.Generic;
using System.Xml.Serialization;
using System.Linq;

public class Equipment : Item, IEquippable
{
    public Equipment() : this("Equipment", "Desc", new Money(), 10, 1, ["prop"], []) { }
    public Equipment(string name, string description, Money price, int weight, int amount,
    List<string> properties, Dictionary<ProficiencyType, RollType> proficiencyModifiers) :
     base(name, description, price, weight, amount)
    {
        Properties = properties;

    }

    [XmlArray]
    [XmlArrayItem("Properties")]
    public List<string> Properties { get; set; }
    [XmlArray("ProficiencyModifiers")]
    [XmlArrayItem("Modifier")]
    public List<ProficiencyModifier> ProficiencyModifiersSerializable
    {
        get
        {
            return ProficiencyModifiers?.Select(kvp => new ProficiencyModifier
            {
                Type = kvp.Key,
                RollType = kvp.Value
            }).ToList() ?? new List<ProficiencyModifier>();
        }
        set
        {
            ProficiencyModifiers = value?.ToDictionary(x => x.Type, x => x.RollType)
                ?? new Dictionary<ProficiencyType, RollType>();
        }
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
