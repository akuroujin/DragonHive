using System.Collections.Generic;
using System.Xml.Serialization;

public class CharacterClass
{
    public string Name { get; init; }
    public int Level { get; init; }

    [XmlArray]
    [XmlArrayItem("Proficiency")]
    public HashSet<ProficiencyType> Proficiencies { get; set; }
    [XmlArray]
    [XmlArrayItem("Proficiency")]
    public HashSet<ProficiencyType> Expertise { get; set; }
    public CharacterClass(string name)
    {
        Name = name;
    }
}
