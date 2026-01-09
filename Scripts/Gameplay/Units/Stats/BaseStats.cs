using Godot;
using Godot.Collections;
[GlobalClass]
public partial class BaseStats : Resource
{
    public BaseStats(int maxHealth = 0, int maxUbi = 0, int walkSpeed = 0, int armorClass = 0)
    {
        this[BaseStatTypes.MaxUbi] = maxUbi;
        this[BaseStatTypes.MaxHealth] = maxHealth;
        this[BaseStatTypes.WalkDistance] = walkSpeed;
        this[BaseStatTypes.ArmorClass] = armorClass;
        this[BaseStatTypes.Initiative] = 0;
    }
    [Export]
    Dictionary<BaseStatTypes, int> _stats = new()
    {
        {BaseStatTypes.MaxHealth, 10},
        {BaseStatTypes.MaxUbi, 10},
        {BaseStatTypes.WalkDistance, 30},
        {BaseStatTypes.SwimmingDistance, 10},
        {BaseStatTypes.ArmorClass, 10},
        {BaseStatTypes.Initiative, 0}
    };

    public int this[BaseStatTypes stat]
    {
        get => _stats[stat];
        set => _stats[stat] = value;
    }
}
