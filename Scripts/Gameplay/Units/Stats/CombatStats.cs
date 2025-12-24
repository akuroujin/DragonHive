using System;

public class CombatStats
{
    public CombatStats(BaseStats stats)
    {
        this[CombatStatTypes.CurrentHealth] = stats[BaseStatTypes.MaxHealth];
        this[CombatStatTypes.RemainingWalkDistance] = stats[BaseStatTypes.WalkDistance];
        this[CombatStatTypes.CurrentUbi] = stats[BaseStatTypes.MaxUbi];
        this[CombatStatTypes.TempHealth] = 0;
    }
    public CombatStats(int CurrentHealth, int CurrentUbi, int RemainingWalkDistance)
    {
        this[CombatStatTypes.CurrentHealth] = CurrentHealth;
        this[CombatStatTypes.CurrentUbi] = CurrentUbi;
        this[CombatStatTypes.RemainingWalkDistance] = 0;
        this[CombatStatTypes.TempHealth] = 0;
    }
    private int[] _stats = new int[Enum.GetNames(typeof(CombatStatTypes)).Length];

    public int this[CombatStatTypes stat]
    {
        get => _stats[(int)stat];
        set => _stats[(int)stat] = value;
    }
}