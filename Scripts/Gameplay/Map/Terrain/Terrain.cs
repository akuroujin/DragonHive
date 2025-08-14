using System;
using System.Linq;

class Terrain
{
    public Terrain(TerrainType type)
    {
        this.Type = type;
    }
    public TerrainType Type { get; private set; }
    public void IncreaseTerrainType()

    {
        Type++;

        if ((int)Type >= Enum.GetValues<TerrainType>().Length)
        {
            Type = 0;
        }
    }
    public void DecreaseTerrainType()

    {
        Type--;

        if ((int)Type < 0)
        {
            Type = (TerrainType)Enum.GetValues<TerrainType>().Length - 1;
        }
    }
}