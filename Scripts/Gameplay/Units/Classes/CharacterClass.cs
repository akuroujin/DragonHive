using Godot.Collections;
using Godot;

[GlobalClass]
public partial class CharacterClass : Resource
{
    public CharacterClass() : this("Class", 1, [], []) { }
    public CharacterClass(string name, int level, Array<SkillTypes> proficiencies, Array<SkillTypes> expertise)
    {
        Name = name;
        Level = level;
        Proficiencies = proficiencies;
        Expertise = expertise;
    }
    [Export]
    public string Name { get; set; }
    [Export]
    public int Level { get; set; }

    [Export]
    public Array<SkillTypes> Proficiencies { get; set; }

    [Export]
    public Array<SkillTypes> Expertise { get; set; }

}
