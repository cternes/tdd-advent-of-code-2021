using System.Collections.Generic;
using System.Drawing;

namespace day5;

public class VentDiagram
{
    private readonly Dictionary<Point, int> map = new Dictionary<Point, int>();

    public Dictionary<Point, int> Draw(List<Vent> vents)
    {
        vents.ForEach(DrawVent);

        return map;
    }

    private void DrawVent(Vent vent)
    {
        vent.Points.ForEach(DrawPoint);
    }

    private void DrawPoint(Point point)
    {
        if (map.TryGetValue(point, out var count))
        {
            map[point] = count + 1;
        }
        else
        {
            map.Add(point, 1);
        }
    }
}