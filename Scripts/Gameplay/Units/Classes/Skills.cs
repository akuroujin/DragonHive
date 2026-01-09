using System.Collections.Generic;

public static class Skills
{
    public static AbilityScoreTypes SkillToAbility(SkillTypes prof)
    {
        return _conversion[prof];
    }
    private static readonly Dictionary<SkillTypes, AbilityScoreTypes> _conversion = new()
    {
        {SkillTypes.Acrobatics, AbilityScoreTypes.Dexterity},
        {SkillTypes.AnimalHandling, AbilityScoreTypes.Wisdom},
        {SkillTypes.Arcana, AbilityScoreTypes.Intelligence},
        {SkillTypes.Athletics, AbilityScoreTypes.Strength},
        {SkillTypes.Deception, AbilityScoreTypes.Charisma},
        {SkillTypes.History, AbilityScoreTypes.Intelligence},
        {SkillTypes.Insight, AbilityScoreTypes.Wisdom},
        {SkillTypes.Intimidation, AbilityScoreTypes.Charisma},
        {SkillTypes.Investigation, AbilityScoreTypes.Intelligence},
        {SkillTypes.Medicine, AbilityScoreTypes.Wisdom},
        {SkillTypes.Nature, AbilityScoreTypes.Intelligence},
        {SkillTypes.Perception, AbilityScoreTypes.Wisdom},
        {SkillTypes.Performance, AbilityScoreTypes.Charisma},
        {SkillTypes.Persuasion, AbilityScoreTypes.Charisma},
        {SkillTypes.Religion, AbilityScoreTypes.Intelligence},
        {SkillTypes.SleightOfHand, AbilityScoreTypes.Dexterity},
        {SkillTypes.Stealth, AbilityScoreTypes.Dexterity},
        {SkillTypes.Survival, AbilityScoreTypes.Wisdom}
    };
}