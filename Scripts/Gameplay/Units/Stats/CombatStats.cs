using System;
using Godot;
using Godot.Collections;
[GlobalClass]
public partial class CombatStats : Resource
{
    public CombatStats(BaseStats stats)
    {
        this[CombatStatTypes.CurrentHealth] = stats[BaseStatTypes.MaxHealth];
        this[CombatStatTypes.RemainingWalkDistance] = stats[BaseStatTypes.WalkDistance];
        this[CombatStatTypes.CurrentUbi] = stats[BaseStatTypes.MaxUbi];
        this[CombatStatTypes.TempHealth] = 0;
    }
    public CombatStats(int CurrentHealth, int CurrentUbi, int RemainingWalkDistance = 0, int TempHealth = 0)
    {
        this[CombatStatTypes.CurrentHealth] = CurrentHealth;
        this[CombatStatTypes.CurrentUbi] = CurrentUbi;
        this[CombatStatTypes.RemainingWalkDistance] = RemainingWalkDistance;
        this[CombatStatTypes.TempHealth] = TempHealth;
    }
    [Export]
    private Dictionary<CombatStatTypes, int> _stats = new()
    {
        {CombatStatTypes.CurrentHealth, 0},
        {CombatStatTypes.CurrentUbi, 0},
        {CombatStatTypes.RemainingWalkDistance, 30},
        {CombatStatTypes.TempHealth, 10},
    };

    public int this[CombatStatTypes stat]
    {
        get => _stats[stat];
        set => _stats[stat] = value;
    }
}