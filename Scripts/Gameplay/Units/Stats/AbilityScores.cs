using System;
using System.Xml.Serialization;
using System.Linq;
public class AbilityScores
{
    public AbilityScores(int str, int dex, int con, int intel, int wis, int cha)
    {
        this[AbilityScoreTypes.Strength] = str;
        this[AbilityScoreTypes.Dexterity] = dex;
        this[AbilityScoreTypes.Constitution] = con;
        this[AbilityScoreTypes.Intelligence] = intel;
        this[AbilityScoreTypes.Wisdom] = wis;
        this[AbilityScoreTypes.Charisma] = cha;
    }

    private int[] _stats = new int[Enum.GetNames(typeof(AbilityScoreTypes)).Length];

    public int this[AbilityScoreTypes stat]
    {
        get => _stats[(int)stat];
        set => _stats[(int)stat] = value;
    }
}
