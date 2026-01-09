using Godot;

[GlobalClass]
public partial class Stats : Resource
{
    public Stats(AbilityScores scores, BaseStats baseStats, CombatStats combatStats)
    {
        _abilityScores = scores;
        _baseStats = baseStats;
        _combatStats = combatStats;
    }
    [Export]
    private AbilityScores _abilityScores;
    public int this[AbilityScoreTypes stat]
    {
        get => _abilityScores[stat];
        set => _abilityScores[stat] = value;
    }
    [Export]
    private BaseStats _baseStats;
    public int this[BaseStatTypes stat]
    {
        get => _baseStats[stat];
        set => _baseStats[stat] = value;
    }
    [Export]
    private CombatStats _combatStats;

    public int this[CombatStatTypes stat]
    {
        get => _combatStats[stat];
        set => _combatStats[stat] = value;
    }
    public static Stats operator +(Stats a, Stats b)
    {
        //TODO: Stat addition
        return null;
    }
    public static Stats operator +(Stats a, BaseStats b)
    {
        //TODO: base stataddition
        return null;
    }
}