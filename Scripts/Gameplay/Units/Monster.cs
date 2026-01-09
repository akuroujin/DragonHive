using System;
using Godot;
using Godot.Collections;
[GlobalClass]
public partial class Monster : Unit
{
    public Monster(string name, Stats stats, Array<Resistance> resistances, Array<Attack> attacks, Inventory inv, Array<Equipment> equipment) : base(name, stats, resistances, attacks, inv, equipment)
    {
    }

    [Export]
    public int ChallengeRating { get; set; }
    [Export]
    public Array<SkillTypes> Proficiencies { get; set; }


    private int ProficiencyBonus => 2 + (ChallengeRating - 1) / 4;

    public override int GetSkillRoll(SkillTypes proficiencyType)
    {
        int roll = GetStatRoll(Skills.SkillToAbility(proficiencyType));
        if (!Proficiencies.Contains(proficiencyType))
            return roll;
        return roll + ProficiencyBonus;
    }

    public override IExportable Import(string filePath)
    {
        throw new NotImplementedException();
    }

    public override string ToXML(string filePath)
    {
        throw new NotImplementedException();
    }
}
