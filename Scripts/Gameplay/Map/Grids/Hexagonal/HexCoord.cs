using System;
using System.Collections.Generic;
using Godot;

public class HexCoord : TileCoord
{
    public int Q { get; private set; }
    public int R { get; private set; }
    public int S { get; private set; }
    public HexCoord(int q, int r)
    {
        Q = q;
        R = r;
        S = -q - r;
        Terrain = TerrainType.Normal;
    }
    public HexCoord(int q, int r, int s)
    {
        Q = q;
        R = r;
        S = s;
        Terrain = TerrainType.Normal;
    }


    #region Readonly

    public enum Directions
    {
        E,
        NE,
        NW,
        W,
        SW,
        SE
    }
    public static new readonly HexCoord[] Direction = [
        new HexCoord(1, 0, -1), // East
        new HexCoord(1, -1, 0), // NEast
        new HexCoord(0, -1, 1), // NWest
        new HexCoord(-1, 0, 1), // West
        new HexCoord(-1, 1, 0), // SWest
        new HexCoord(0, 1, -1)  // SEast
    ];
    #endregion
    public enum HexDirections
    {
        E,
        NE,
        NW,
        W,
        SW,
        SE
    }

    #region Methods
    public override Vector2 ToPosition(float size)
    {
        // float x = R % 2 * size * 0.9f / 2 + Q * size * 0.9f;
        // float y = R * size * 0.8f;
        // return new Vector2(x, y);
        float x = (Q * HexLayout.Pointy.F0 + R * HexLayout.Pointy.F1) * size * 0.5f;
        float y = (HexLayout.Pointy.F2 * Q + HexLayout.Pointy.F3 * R) * size * 0.5f;
        // GD.Print($"{LayoutPointy.f0} - {Mathf.Sqrt(3)} | {LayoutPointy.f1} - {Mathf.Sqrt(3) / 2}");
        return new Vector2(x, y);
    }
    public override bool Equals(object obj)
    {
        if (obj == null) return false;
        if (!(obj is HexCoord)) return false;
        var other = obj as HexCoord;
        return other.S == S && other.Q == Q && other.R == R;
    }
    public override string ToString()
    {
        string value = "(";
        value += "Q: " + Q;
        value += ", R: " + R;
        value += ", S: " + S;
        value += ")";
        return value;
    }
    public override int GetHashCode() => (Q, R, S).GetHashCode();
    public override int GetLength(TileCoord coord)
    {
        if (coord is not HexCoord)
        {
            return -1;
        }
        HexCoord hex = coord as HexCoord;
        return (Math.Abs(hex.Q) + Math.Abs(hex.R) + Math.Abs(hex.S)) / 2;
    }

    public override int GetDistance(TileCoord coord)
    {
        if (coord is not HexCoord)
        {
            return -1;
        }
        HexCoord hex = coord as HexCoord;
        return GetLength(this - hex);
    }
    public override HexCoord GetDirection(int direction)
    {

        return this + Direction[direction];
    }
    public override List<TileCoord> GetReachable(int range, TerrainType passable)
    {
        List<TileCoord> reachable = new();
        List<List<HexCoord>> fringes = new();
        reachable.Add(this);
        fringes.Add(new List<HexCoord>());
        fringes[0].Add(this);
        for (int i = 1; i <= range; i++)
        {
            fringes.Add(new List<HexCoord>());
            foreach (HexCoord fringe in fringes[i - 1])
            {
                foreach (HexCoord dir in Direction)
                {
                    HexCoord neighbour = fringe + dir;
                    if (!GridManager.Instance.Tiles.ContainsKey(neighbour)) continue;
                    if (reachable.Contains(neighbour) || passable < GridManager.Instance.Tiles[neighbour].Coord.Terrain) continue;
                    fringes[i].Add(neighbour);
                    reachable.Add(neighbour);

                }
            }
        }
        return reachable;
    }

    public static List<TileCoord> GenerateTiles()
    {
        //
        return null;
    }

    #endregion

    #region Operators
    public static HexCoord operator +(HexCoord a, HexCoord b)
    {
        return new HexCoord(a.Q + b.Q, a.R + b.R, a.S + b.S);
    }
    public static HexCoord operator -(HexCoord a, HexCoord b)
    {
        return new HexCoord(a.Q - b.Q, a.R - b.R, a.S - b.S);
    }
    public static HexCoord operator *(HexCoord a, int b)
    {
        return new HexCoord(a.Q * b, a.R * b, a.S * b);
    }
    #endregion
}