using Godot;
using Godot.Collections;
[GlobalClass]
public partial class AbilityScores : Resource
{
    public AbilityScores(int str = 0, int dex = 0, int con = 0, int intel = 0, int wis = 0, int cha = 0)
    {
        // this[AbilityScoreTypes.Strength] = str;
        // this[AbilityScoreTypes.Dexterity] = dex;
        // this[AbilityScoreTypes.Constitution] = con;
        // this[AbilityScoreTypes.Intelligence] = intel;
        // this[AbilityScoreTypes.Wisdom] = wis;
        // this[AbilityScoreTypes.Charisma] = cha;
    }
    [Export]
    Dictionary<AbilityScoreTypes, int> _stats = new()
    {
        {AbilityScoreTypes.Strength,0},
        {AbilityScoreTypes.Dexterity,0},
        {AbilityScoreTypes.Constitution,0},
        {AbilityScoreTypes.Intelligence,0},
        {AbilityScoreTypes.Wisdom,0},
        {AbilityScoreTypes.Charisma,0}
    };

    public int this[AbilityScoreTypes stat]
    {
        get => _stats[stat];
        set => _stats[stat] = value;
    }
}
