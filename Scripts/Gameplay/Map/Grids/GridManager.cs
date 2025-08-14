using System.Collections.Generic;
using Godot;

class GridManager
{
    private GridManager() { }
    public Dictionary<TileCoord, BaseTile> Tiles;
    private int _width;
    private int _height;
    public void SetSize(int width, int height)
    {
        _width = width;
        _height = height;
    }
    public enum AmountType
    {
        Height,
        Width
    }

    private int _heightAmount;
    private int _widthAmount;

    public float TileSize { get; private set; }
    public float TileWidth
    {
        get
        {
            if (TileType == TileType.Square)
            {
                return TileSize;
            }
            else
            {
                return TileSize * 1.15f;
            }
        }
    }
    public float TileHeight
    {
        get
        {
            if (TileType == TileType.Square)
            {
                return TileSize;
            }
            else
            {
                return TileSize * Mathf.Sqrt(3) / 2;
            }
        }
    }
    public static TileType TileType;

    public void SetAmount(int amount, AmountType type)
    {

        if (type == AmountType.Height)
        {
            _heightAmount = amount;
            TileSize = _height / _heightAmount;
            GD.Print(_height / _heightAmount);
            _widthAmount = (int)(_width / TileWidth);
        }
        if (type == AmountType.Width)
        {
            _widthAmount = amount;
            TileSize = _width / _widthAmount;

            GD.Print((float)_width / _widthAmount);
            _heightAmount = (int)(_height / TileHeight);
        }
    }

    private static GridManager _instance;
    public static GridManager Instance
    {
        get
        {
            _instance ??= new GridManager();
            return _instance;
        }
    }
    public void GenerateTiles()
    {
        TileSize = _width / _widthAmount;

    }
    public void DestroyTiles()
    {
        foreach (BaseTile tile in Tiles.Values)
        {
            tile.QueueFree();
        }
        Tiles.Clear();
    }
}