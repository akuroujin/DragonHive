class MapManager
{
    private MapManager() { }
    public static MapManager Instance
    {
        get
        {
            _instace ??= new MapManager();
            return _instace;
        }
    }
    private static MapManager _instace;


}