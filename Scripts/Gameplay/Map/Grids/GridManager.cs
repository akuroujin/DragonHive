using System.Collections.Generic;
using Godot;

class GridManager
{
    public Control parent;
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

    public int HeightAmount { get; private set; }
    public int WidthAmount { get; private set; }


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
    public TileType TileType;

    public void SetAmount(int amount, AmountType type)
    {

        if (type == AmountType.Height)
        {
            HeightAmount = amount;
            TileSize = _height / HeightAmount;
            GD.Print(_height / HeightAmount);
            WidthAmount = (int)(_width / TileWidth);
        }
        if (type == AmountType.Width)
        {
            WidthAmount = amount;
            TileSize = _width / WidthAmount;

            GD.Print((float)_width / WidthAmount);
            HeightAmount = (int)(_height / TileHeight);
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
        TileSize = _width / WidthAmount;

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