using System;
using System.Collections.Generic;
using System.Numerics;
using System.Xml.Serialization;

public class PlayerCharacter : Unit, IExportable
{
    public PlayerCharacter(string name, List<Resistance> resistances, List<Attack> attacks, List<Spell> spells, List<Item> inventory,
    List<Equipment> equipment, AbilityScores baseStats, BaseStats stats, int experience, List<CharacterClass> classes,
    List<SubClass> subClasses) : base(name, resistances, attacks, spells, inventory, equipment, baseStats, stats)
    {
        Experience = experience;
        Classes = classes;
        SubClasses = subClasses;
    }

    #region Properties
    [XmlElement]
    public int Experience { get; set; }
    [XmlIgnore]
    public int CharacterLevel
    {
        get
        {
            return Level.GetLevel(Experience);
        }
    }
    [XmlArray]
    public List<CharacterClass> Classes { get; set; }

    [XmlArray]
    public List<SubClass> SubClasses { get; set; }

    [XmlIgnore]
    public int ProficiencyBonus => 2 + (CharacterLevel - 1) / 4;

    #endregion
    private bool isDowned => this[CombatStatTypes.CurrentHealth] <= 0;
    private int deathFailCount = 0;
    private int deathSuccessCount = 0;



    public override int GetProficiencyRoll(ProficiencyType proficiencyType)
    {
        int roll = GetStatRoll((AbilityScoreTypes)proficiencyType);
        int value = roll;
        if (Classes[0].Proficiencies.Contains(proficiencyType))
            value += ProficiencyBonus;
        if (Classes[0].Expertise.Contains(proficiencyType))
            value += ProficiencyBonus;
        return value;

    }
    private void DeathThrow()
    {
        int roll = Dice.Roll(DiceTypes.D20);
        switch (roll)
        {
            case 1:
                deathFailCount += 2;
                break;
            case 20:
                Revive();
                break;
            case < 10:
                deathFailCount++;
                break;
            case > 10:
                deathSuccessCount++;
                break;
            default:
                break;
        }
        if (deathFailCount >= 3)
            Die();
        if (deathSuccessCount >= 3)
            Revive();
    }
    protected override void Heal(int heal)
    {
        if (isDowned)
        {
            Revive();
            heal -= 1;
        }
        base.Heal(heal);
    }

    private void Revive()
    {
        deathFailCount = 0;
        deathSuccessCount = 0;
        base.Heal(1);
    }
    protected override void TakeDamage(int damage)
    {
        base.TakeDamage(damage);
        if (isDowned)
        {
            DeathThrow();
        }
    }
    public override int GetSaveRoll(AbilityScoreTypes stat)
    {
        return base.GetSaveRoll(stat);
    }

    //TODO: Implement export/import
    public override IExportable Import(string filePath)
    {
        throw new NotImplementedException();
    }

    public override string ToXML(string filePath)
    {
        throw new NotImplementedException();
    }

}
