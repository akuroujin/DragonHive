using System.Collections.Generic;
using Godot;

abstract partial class BaseTile : TextureRect
{
    public TileCoord Coord;
    public bool Selected { get; private set; }
    private int _currentRange;
    private TerrainType _currentTerrainType;
    private List<BaseTile> _selectedTiles;
    private List<BaseTile> _selectedBy;

    public abstract void Initialize();

    public void GetSelected(BaseTile tile)
    {
        _selectedBy.Add(tile);
        Modulate = Colors.Orange;
    }
    public void GetDeselected(BaseTile tile)
    {
        _selectedBy.Remove(tile);
        if (_selectedBy.Count == 0)
        {
            Modulate = Colors.White;
        }
    }
    void SelectTiles(int range)
    {
        _selectedTiles.Clear();
        foreach (TileCoord coord in Coord.GetReachable(range, TerrainType.Normal))
        {
            _selectedTiles.Add(GridManager.Instance.Tiles[coord]);
            GridManager.Instance.Tiles[coord].GetSelected(this);
        }
        this.Modulate = Colors.Green;
    }
    void DeselectTiles()
    {
        foreach (BaseTile tile in _selectedTiles)
        {
            tile.Modulate = Modulate;
            tile.GetDeselected(this);
        }
        _selectedTiles.Clear();
    }
    public void OnClick()
    {
        if (Selected)
        {
            SelectTiles(5);
        }
        else
        {
            DeselectTiles();
        }
    }

}
