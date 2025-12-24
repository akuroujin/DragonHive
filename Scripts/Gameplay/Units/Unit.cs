using Godot;
using System;
using System.Collections.Generic;
using System.Xml.Serialization;

public abstract class Unit : ITurnPhases, IExportable, IRange
{
    protected Unit(string name, List<Resistance> resistances, List<Attack> attacks, List<Spell> spells, List<Item> inventory, List<Equipment> equipment, AbilityScores baseStats, BaseStats stats)
    {
        Name = name;
        Resistances = resistances;
        Attacks = attacks;
        Spells = spells;
        Inventory = inventory;
        this.Equipment = equipment;
        AbilityScores = baseStats;
        BaseStats = stats;
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


    public string Name { get; set; }

    private List<Resistance> Resistances;

    public List<Attack> Attacks { get; set; }

    public List<Spell> Spells { get; set; }
    public List<Item> Inventory { get; set; }
    public List<Equipment> Equipment { get; set; }
    private AbilityScores _abilityScores;
    public AbilityScores AbilityScores
    {
        get => _abilityScores;
        private set => _abilityScores = value;
    }
    public int this[AbilityScoreTypes stat]
    {
        get => _abilityScores[stat];
        protected set => _abilityScores[stat] = value;
    }

    private BaseStats _baseStats;
    public BaseStats BaseStats
    {
        get => _baseStats;
        set => _baseStats = value;
    }
    public int this[BaseStatTypes stat]
    {
        get => _baseStats[stat];
        protected set => _baseStats[stat] = value;
    }
    private CombatStats _combatStats;

    public int this[CombatStatTypes stat]
    {
        get => _combatStats[stat];
        protected set => _combatStats[stat] = value;
    }

    bool _didAction = false;
    bool _didBonusAction = false;
    Spell _currentAttack = null;

    #endregion

    #region Combat

    // Elements on this unit
    [XmlIgnore]
    public List<Element> takenElements = new List<Element>();

    // Effect given to other units
    [XmlIgnore]
    public List<IEffect> givenEffects = new List<IEffect>();

    #endregion

    #region Methods
    public abstract int GetProficiencyRoll(ProficiencyType proficiencyType);

    public int GetPassiveProficiency(ProficiencyType proficiencyType)
    {
        return 10 + (this[(AbilityScoreTypes)proficiencyType] - 10) / 2;
    }
    public int GetStatRoll(AbilityScoreTypes stat)
    {
        return Dice.Roll(DiceTypes.D20) + (this[stat] - 10) / 2;
    }
    public virtual int GetSaveRoll(AbilityScoreTypes stat)
    {
        return Dice.Roll(DiceTypes.D20) + this[stat] - 10;
    }
    protected virtual void Heal(int heal)
    {
        this[CombatStatTypes.CurrentHealth] += heal;
        if (this[CombatStatTypes.CurrentHealth] > this[BaseStatTypes.MaxHealth])
            this[CombatStatTypes.CurrentHealth] = this[BaseStatTypes.MaxHealth];
    }

    protected virtual void TakeDamage(int damage)
    {
        if (damage < 0)
        {
            Heal(damage);
            return;
        }
        if (damage > this[CombatStatTypes.CurrentHealth])
        {
            Die();
            return;
        }
        if (this[CombatStatTypes.TempHealth] > 0)
        {
            this[CombatStatTypes.TempHealth] -= damage;
            damage = -this[CombatStatTypes.TempHealth];
            if (this[CombatStatTypes.TempHealth] >= 0)
                return;
        }
        this[CombatStatTypes.CurrentHealth] -= damage;
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
        int statroll = roll + GetStatRoll(attack.statType);
        if (statroll < enemy[BaseStatTypes.ArmorClass])
        {
            return;
        }
        enemy.TakeAttack(attack);
        if (roll == 20)
            enemy.TakeAttack(attack, true);
    }
    protected void Die()
    {
        //TODO: change image to desaturated version
    }


    public void StartTurn()
    {
        //TODO: Apply effects
        foreach (IEffect effect in givenEffects)
        {
            effect.Tick();
        }
        _didAction = false;
        _didBonusAction = false;
    }

    public void EndTurn()
    {
        foreach (IEffect effect in givenEffects)
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
        return this[CombatStatTypes.RemainingWalkDistance];
    }

    #endregion
}
