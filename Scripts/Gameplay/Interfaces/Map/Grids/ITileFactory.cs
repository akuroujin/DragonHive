using System.Collections.Generic;
using Godot;

interface ITileFactory
{
    Dictionary<TileCoord, BaseTile> GenerateTiles(Control control);
}