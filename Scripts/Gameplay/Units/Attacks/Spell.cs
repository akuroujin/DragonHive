using Godot;
using Godot.Collections;

[GlobalClass]
public partial class Spell : Attack
{
    public Spell() : this("hit", "hits enemy", [new Damage()], 5, 1, true, false, false, AbilityScoreTypes.Intelligence, 2, 1, 2, [new Element()], 2, 5) { }
    public Spell(string name, string description, Array<Damage> damages, int range, int radius, bool isAction, bool isBonusAction, bool
        isReaction, AbilityScoreTypes statTypes, int level, int castTime, int duration, Array<Element> elements, int amount, int ubiCost,
        bool isHealing = false, LimitType limitType = LimitType.None, int limitAmount = 0, int refillAmount = 0)
    : base(name, description, damages, range, radius, isAction, isBonusAction, isReaction, statTypes)
    {
        Level = level;
        CastTime = castTime;
        Duration = duration;
        Elements = elements;
        Amount = amount;
        UbiCost = ubiCost;
        IsHealing = isHealing;
        LimitType = limitType;
        LimitAmount = limitAmount;
        RefillAmount = refillAmount;
    }

    [ExportGroup("Spell Specific")]
    [Export]
    public int Level { get; set; }
    [Export]
    public int CastTime { get; set; }
    [Export]
    public int Duration { get; set; }
    [Export]
    public Array<Element> Elements { get; set; }
    [Export]
    public int Amount { get; set; }
    [Export]
    public int UbiCost { get; set; }
    [Export]
    public bool IsHealing { get; set; }
    [ExportGroup("Limits")]
    [Export]
    public LimitType LimitType { get; set; }
    [Export]
    public int LimitAmount { get; set; }
    [Export]
    public int RefillAmount { get; set; }

    public override int GetDamage()
    {
        int amount = 0;
        foreach (Damage roll in Damages)
        {
            amount += roll.GetDamage();
        }
        return IsHealing ? amount : -amount;
    }

}
