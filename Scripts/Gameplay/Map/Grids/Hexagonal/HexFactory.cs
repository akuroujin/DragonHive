using System.Collections.Generic;
using Godot;
class HexFactory : ITileFactory
{
    public Dictionary<TileCoord, BaseTile> GenerateTiles(Control control)
    {
        Dictionary<TileCoord, BaseTile> tiles = new();
        for (int r = 0; r < GridManager.Instance.HeightAmount; r++)
        {
            int r_offset = r / 2;
            int r_limit = r % 2;
            for (int q = 0 - r_offset; q < GridManager.Instance.WidthAmount - r_offset - r_limit; q++)
            {
                HexTile tile = GD.Load<PackedScene>("res://Hexagonal Tiles/Tile.tscn").Instantiate<HexTile>();
                tile.Initialize(new HexCoord(q, r));
                tiles.Add(tile.Coord, tile);
                control.AddChild(tile);
            }
        }
        return tiles;
    }
}
