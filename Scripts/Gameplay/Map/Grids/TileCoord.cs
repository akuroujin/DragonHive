using System;
using System.Collections.Generic;
using Godot;

public abstract class TileCoord
{

    public TerrainType Terrain { get; protected set; }

    public static readonly TileCoord[] Direction;
    /// <summary>
    /// Returns the length of the line to a tile
    /// </summary>
    /// <param name="coord"></param>
    /// <returns></returns>
    public abstract int GetLength(TileCoord coord);
    /// <summary>
    /// Returns distance from current coordinate to another
    /// </summary>
    /// <param name="coord">Other Coordinate</param>
    /// <returns></returns>
    public abstract int GetDistance(TileCoord coord);
    /// <summary>
    /// Lists all reachable tiles around current tile in a set range
    /// </summary>
    /// <param name="range">Maximum range of search</param>
    /// <param name="passable">Roughest terrain that the search can pass thorugh</param>
    /// <returns></returns>
    public abstract List<TileCoord> GetReachable(int range, TerrainType passable);
    /// <summary>
    /// Returns the neighbouring coordinate in a direction
    /// </summary>
    /// <param name="direction"></param>
    /// <returns></returns>
    public abstract TileCoord GetDirection(int direction);
    /// <summary>
    /// Converts current position to Godot's position
    /// </summary>
    /// <param name="size"></param>
    /// <returns></returns>
    public abstract Vector2 ToPosition(float size);
}