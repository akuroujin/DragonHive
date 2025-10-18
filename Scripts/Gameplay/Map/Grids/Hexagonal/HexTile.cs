using Godot;
partial class HexTile : BaseTile
{
    public override void Initialize(TileCoord coord)
    {
        Coord = coord;
        this.Scale = Vector2.One * GridManager.Instance.TileWidth / Size;
        Position = coord.ToPosition(GridManager.Instance.TileWidth);
    }
}