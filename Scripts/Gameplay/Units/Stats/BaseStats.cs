using System;
public class BaseStats
{
    public BaseStats(int maxHealth, int maxUbi, int walkSpeed, int armorClass)
    {
        this[BaseStatTypes.MaxUbi] = maxUbi;
        this[BaseStatTypes.MaxHealth] = maxHealth;
        this[BaseStatTypes.WalkDistance] = walkSpeed;
        this[BaseStatTypes.ArmorClass] = armorClass;
        this[BaseStatTypes.Initiative] = 0;
    }
    public BaseStats(int maxUbi, int maxHealth, int walkSpeed, int armorClass, int Initiative) : this(maxHealth, maxUbi, walkSpeed, armorClass)
    {
        this[BaseStatTypes.Initiative] = Initiative;
    }

    private int[] _stats = new int[Enum.GetNames(typeof(BaseStatTypes)).Length];
    public int this[BaseStatTypes stat]
    {
        get => _stats[(int)stat];
        set => _stats[(int)stat] = value;
    }
}
