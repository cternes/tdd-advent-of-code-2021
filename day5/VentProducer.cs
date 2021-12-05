using System.Collections.Generic;
using System.Drawing;
using System.Linq;

namespace day5;

public class VentProducer
{
    public static List<Vent> CreateVents(List<string> lines, bool ignoreDiagonals = true)
    {
        return lines.Select(i => ParseLine(i, ignoreDiagonals)).ToList();
    }

    private static Vent ParseLine(string line, bool ignoreDiagonals)
    {
        var splitted = line.Split(" -> ");
        var start = ParsePoint(splitted[0]);
        var end = ParsePoint(splitted[1]);

        return new Vent(start, end, ignoreDiagonals);
    }

    private static Point ParsePoint(string value)
    {
        var splitted = value.Split(',');
        var x = int.Parse(splitted[0]);
        var y = int.Parse(splitted[1]);

        return new Point(x, y);
    }
}