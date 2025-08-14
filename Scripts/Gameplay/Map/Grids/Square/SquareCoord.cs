using System;
using System.Collections.Generic;
using Godot;

class SquareCoord : TileCoord
{
    public int X { get; private set; }
    public int Y { get; private set; }
    public SquareCoord(int x, int y)
    {
        X = x;
        Y = y;
    }
    #region Readonly
    public enum Directions
    {
        E,
        S,
        W,
        N
    }
    public static new readonly SquareCoord[] Direction = [
        new SquareCoord(1, 0), //E
        new SquareCoord(0, 1), //S 
        new SquareCoord(-1, 0), //W
        new SquareCoord(0, -1), //N

    ];
    #endregion
    public override TileCoord GetDirection(int direction)
    {
        return this + Direction[direction];
    }

    public override int GetDistance(TileCoord coord)
    {
        if (coord is not SquareCoord)
        {
            return -1;
        }
        SquareCoord square = coord as SquareCoord;
        return GetLength(this - square);
    }

    public override int GetLength(TileCoord coord)
    {
        if (coord is not SquareCoord)
        {
            return -1;
        }
        SquareCoord square = coord as SquareCoord;
        return (Math.Abs(square.X) + Math.Abs(square.Y)) / 2;
    }

    public override List<TileCoord> GetReachable(int range, TerrainType passable)
    {
        List<TileCoord> reachable = new();
        List<List<SquareCoord>> fringes = new();
        reachable.Add(this);
        fringes.Add(new List<SquareCoord>());
        fringes[0].Add(this);
        for (int i = 1; i <= range; i++)
        {
            fringes.Add(new List<SquareCoord>());
            foreach (SquareCoord fringe in fringes[i - 1])
            {
                foreach (SquareCoord dir in Direction)
                {
                    SquareCoord neighbour = fringe + dir;
                    if (!GridManager.Instance.Tiles.ContainsKey(neighbour)) continue;
                    if (reachable.Contains(neighbour) || passable < GridManager.Instance.Tiles[neighbour].Coord.Terrain) continue;
                    fringes[i].Add(neighbour);
                    reachable.Add(neighbour);

                }
            }
        }
        return reachable;
    }

    public override Vector2 ToPosition(float size)
    {
        return new Vector2(X * size, Y * size);
    }

    #region Operators
    public static SquareCoord operator +(SquareCoord a, SquareCoord b)
    {
        return new SquareCoord(a.X + b.X, a.Y + b.Y);
    }
    public static SquareCoord operator -(SquareCoord a, SquareCoord b)
    {
        return new SquareCoord(a.X - b.X, a.Y - b.Y);
    }
    public static SquareCoord operator *(SquareCoord a, int b)
    {
        return new SquareCoord(a.X * b, a.Y * b);
    }
    #endregion
}
