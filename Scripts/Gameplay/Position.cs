using System.Collections.Generic;
using System.Linq;

public class Position
{
    public int X { get; set; }
    public int Y { get; set; }
    public void test()
    {
        List<Position> list = new();
        Position above = list.FindAll(x => x.Y > this.Y).OrderBy(other => GetDistance(other)).First();
    }
    public int GetDistance(Position other)
    {
        return 0;
    }
}