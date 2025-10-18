using System.Collections.Generic;
using System.Xml.Serialization;

public class CharacterClass
{
    public CharacterClass() : this("Class", 1, [], []) { }
    public CharacterClass(string name, int level, HashSet<ProficiencyType> proficiencies, HashSet<ProficiencyType> expertise)
    {
        Name = name;
        Level = level;
        Proficiencies = proficiencies;
        Expertise = expertise;
    }
    public string Name { get; init; }
    public int Level { get; init; }

    [XmlArray]
    [XmlArrayItem("Proficiency")]
    public HashSet<ProficiencyType> Proficiencies { get; set; }

    [XmlArray]
    [XmlArrayItem("Expteriese")]
    public HashSet<ProficiencyType> Expertise { get; set; }

}
