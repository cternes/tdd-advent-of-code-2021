using System.Collections.Generic;
using System.Drawing;
using System.Threading;

namespace day5;

public record Vent(Point Start, Point End, bool IgnoreDiagonals = true)
{
    public List<Point> Points
    {
        get
        {
            var list = new List<Point>();
            if (Start.X != End.X && Start.Y != End.Y)
            {
                if (IgnoreDiagonals)
                {
                    return new List<Point>();
                }

                if (Start.X < End.X && Start.Y < End.Y)
                {
                    var count = 0;
                    for (var i = Start.X; i <= End.X; i++)
                    {
                        list.Add(new Point(Start.X + count, Start.Y + count));
                        count++;
                    }

                    return list;
                }

                if (Start.X > End.X && Start.Y > End.Y)
                {
                    var count = 0;
                    for (var i = Start.X; i >= End.X; i--)
                    {
                        list.Add(new Point(Start.X - count, Start.Y - count));
                        count++;
                    }

                    return list;
                }

                if (Start.X > End.X && Start.Y < End.Y)
                {
                    var count = 0;
                    for (var i = Start.X; i >= End.X; i--)
                    {
                        list.Add(new Point(Start.X - count, Start.Y + count));
                        count++;
                    }

                    return list;
                }

                if (Start.X < End.X && Start.Y > End.Y)
                {
                    var count = 0;
                    for (var i = Start.X; i <= End.X; i++)
                    {
                        list.Add(new Point(Start.X + count, Start.Y - count));
                        count++;
                    }

                    return list;
                }
            }
            
            if (Start.X < End.X)
            {
                for (var i = Start.X; i <= End.X; i++)
                {
                    list.Add(new Point(i, Start.Y));
                }
            }

            if (Start.X > End.X)
            {
                for (var i = Start.X; i >= End.X; i--)
                {
                    list.Add(new Point(i, Start.Y));
                }
            }

            if (Start.Y < End.Y)
            {
                for (var i = Start.Y; i <= End.Y; i++)
                {
                    list.Add(new Point(Start.X, i));
                }
            }

            if (Start.Y > End.Y)
            {
                for (var i = Start.Y; i >= End.Y; i--)
                {
                    list.Add(new Point(Start.X, i));
                }
            }

            return list;
        }
    }
}