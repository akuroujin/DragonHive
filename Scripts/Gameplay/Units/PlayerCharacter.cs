using System;
using Godot;
using Godot.Collections;


[GlobalClass]
public partial class PlayerCharacter : Unit, IExportable
{

    public PlayerCharacter(string name, Stats stats, Array<Resistance> resistances, Array<Attack> attacks, Inventory inv, Array<Equipment> equipment)
     : base(name, stats, resistances, attacks, inv, equipment)
    {
    }

    public PlayerCharacter(string name, Stats stats, int experience) : base(name, stats)
    {
    }

    #region Properties
    public int Experience { get; set; }

    public int CharacterLevel
    {
        get
        {
            return Level.GetLevel(Experience);
        }
    }

    [Export]
    public Array<CharacterClass> Classes { get; set; } = new();

    [Export]
    public Array<SubClass> SubClasses { get; set; } = new();

    public int ProficiencyBonus => 2 + (CharacterLevel - 1) / 4;

    #endregion
    private bool isDowned => UnitStats[CombatStatTypes.CurrentHealth] <= 0;
    private int deathFailCount = 0;
    private int deathSuccessCount = 0;



    public override int GetSkillRoll(SkillTypes skillType)
    {
        int roll = GetStatRoll(Skills.SkillToAbility(skillType));
        int value = roll;
        if (Classes[0].Proficiencies.Contains(skillType))
            value += ProficiencyBonus;
        if (Classes[0].Expertise.Contains(skillType))
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

    public void ShortRest()
    {
        //TODO: Implement short rest
    }
    public void LongRest()
    {
        //TODO: Implement long rest
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
