using Godot;
using Godot.Collections;


[GlobalClass]
public partial class Attack : Resource, IExportable, IDamage
{
    public Attack() : this("hit", "hits enemy", [new Damage()], 5, 1, true, false, false, AbilityScoreTypes.Strength) { }
    public Attack(string name, string description, Array<Damage> damages, int range, int radius, bool isAction,
        bool isBonusAction, bool isReaction, AbilityScoreTypes statTypes)
    {
        Name = name;
        Description = description;
        Damages = damages;
        Range = range;
        Radius = radius;
        IsAction = isAction;
        IsBonusAction = isBonusAction;
        IsReaction = isReaction;
    }

    public string ID
    {
        get
        {
            string value = Name.ToLower();
            value = value.Trim();
            value = value.Replace(' ', '_');
            return value;
        }
    }
    [Export] public string Name { get; set; }
    [Export] public string Description { get; set; }


    [ExportGroup("Properties")]
    [Export] public Array<Damage> Damages { get; set; }
    [Export] int RollModifier;

    [Export]
    public int Range { get; set; }


    [Export]
    public AbilityScoreTypes StatType { get; set; }

    [Export]
    int Radius { get; set; }

    [ExportGroup("ActionType")]
    [Export]
    public bool IsAction { get; set; }

    [Export]
    public bool IsBonusAction { get; set; }

    [Export]
    public bool IsReaction { get; set; }


    public virtual int GetDamage()
    {
        int amount = 0;
        foreach (Damage roll in Damages)
        {
            amount += roll.GetDamage();
        }
        return amount;
    }

    public string ToXML(string filePath)
    {
        throw new System.NotImplementedException();
    }

    public IExportable Import(string filePath)
    {
        throw new System.NotImplementedException();
    }
}
