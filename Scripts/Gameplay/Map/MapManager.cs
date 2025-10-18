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
    public IRange Selected;
    public int CurrentRange { get { return Selected.GetRange(); } }

}