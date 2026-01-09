using Godot;
using Godot.Collections;

[GlobalClass]
public abstract partial class Unit : Resource, ITurnPhases, IExportable, IRange
{
    protected Unit(string name, Stats stats)
    {
        Name = name;
        _stats = stats;
    }
    protected Unit(string name, Stats stats, Array<Resistance> resistances, Array<Attack> attacks, Inventory inv, Array<Equipment> equipment)
    {
        Name = name;
        _stats = stats;
        Resistances = resistances;
        Attacks = attacks;
        UnitInventory = inv;
        Equipment = equipment;
    }

    #region Properties

    public string UID
    {
        get
        {
            string value = Name.ToLower();
            value = value.Trim();
            value = value.Replace(' ', '_');
            return value;
        }
    }

    [Export]
    public string Name { get; set; }
    private Stats _stats;

    //TODO: Max health based on stats, class + roll
    [Export]
    public Stats UnitStats { get; private set; }

    [Export]
    public Array<Resistance> Resistances = new();

    [Export]
    public Array<Attack> Attacks { get; set; } = new();

    [Export]
    public Inventory UnitInventory { get; set; } = new();

    [Export]
    public Array<Equipment> Equipment { get; set; } = new();
    bool _didAction = false;
    bool _didBonusAction = false;
    Spell _currentAttack = null;

    #endregion

    #region Singals
    [Signal] public delegate void DeathEventHandler();
    [Signal] public delegate void DamageTakenEventHandler();
    #endregion

    #region Combat

    // Elements on this unit

    public Array<Element> takenElements = new Array<Element>();

    // Effect given to other units
    public Array<BaseEffect> givenEffects = new Array<BaseEffect>();

    #endregion

    #region Methods
    public abstract int GetSkillRoll(SkillTypes proficiencyType);

    public int GetPassiveProficiency(SkillTypes proficiencyType)
    {
        return 10 + (_stats[(AbilityScoreTypes)proficiencyType] - 10) / 2;
    }
    public int GetStatRoll(AbilityScoreTypes stat)
    {
        return Dice.Roll(DiceTypes.D20) + (_stats[stat] - 10) / 2;
    }
    public virtual int GetSaveRoll(AbilityScoreTypes stat)
    {
        return Dice.Roll(DiceTypes.D20) + _stats[stat] - 10;
    }
    protected virtual void Heal(int heal)
    {
        _stats[CombatStatTypes.CurrentHealth] += heal;
        if (_stats[CombatStatTypes.CurrentHealth] > _stats[BaseStatTypes.MaxHealth])
            _stats[CombatStatTypes.CurrentHealth] = _stats[BaseStatTypes.MaxHealth];
    }

    protected virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Heal(damage);
            return;
        }
        if (damage > _stats[CombatStatTypes.CurrentHealth])
        {
            Die();
            return;
        }
        if (_stats[CombatStatTypes.TempHealth] > 0)
        {
            _stats[CombatStatTypes.TempHealth] -= damage;
            damage = -_stats[CombatStatTypes.TempHealth];
            if (_stats[CombatStatTypes.TempHealth] >= 0)
                return;
        }
        _stats[CombatStatTypes.CurrentHealth] -= damage;
    }

    public void TakeOtherDamage(int damage, string reason)
    {
        TakeDamage(damage);
        //TODO Log reason
    }

    public void TakeAttack(Attack attack, bool isCritical = false)
    {
        TakeDamage(attack.GetDamage());
        if (isCritical)
            TakeDamage(attack.GetDamage());
    }

    public void TakeAttack(Spell spell, bool isCritical = false)
    {
        TakeAttack(spell as Attack, isCritical);
        foreach (Element element in spell.Elements)
        {
            takenElements.Add(element);
        }
    }

    public void AttackEnemy(Unit enemy, Attack attack)
    {
        int roll = Dice.Roll(DiceTypes.D20);
        int statroll = roll + GetStatRoll(attack.StatType);
        if (statroll < enemy.UnitStats[BaseStatTypes.ArmorClass])
        {
            return;
        }
        enemy.TakeAttack(attack);
        if (roll == 20)
            enemy.TakeAttack(attack, true);
    }
    protected void Die()
    {

        EmitSignalDeath();
        //TODO: change image to desaturated version
    }


    public void StartTurn()
    {
        //TODO: Apply effects
        foreach (BaseEffect effect in givenEffects)
        {
            effect.Tick();
        }
        _didAction = false;
        _didBonusAction = false;
    }

    public void EndTurn()
    {
        foreach (BaseEffect effect in givenEffects)
        {
            if (effect.GetDurationLeft() == 0)
            {
                effect.Finish();
                givenEffects.Remove(effect);
            }
        }
        //TODO: Remove elements with 0 duration
    }



    public abstract IExportable Import(string filePath);

    public abstract string ToXML(string filePath);

    public int GetRange()
    {
        return _stats[CombatStatTypes.RemainingWalkDistance];
    }

    #endregion
}
