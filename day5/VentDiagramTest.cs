using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace day5;

public class VentDiagramTest
{
    [Fact]
    public void ShouldDrawSingleVent()
    {
        // Arrange
        var vents = new List<Vent>
        {
            new Vent(new Point(7, 4), new Point(7, 0)),
        };

        var diagram = new VentDiagram();
        
        // Act
        var map = diagram.Draw(vents);

        // Assert
        map[new Point(7, 4)].Should().Be(0);
        map[new Point(7, 3)].Should().Be(0);
        map[new Point(7, 2)].Should().Be(0);
        map[new Point(7, 1)].Should().Be(0);
        map[new Point(7, 0)].Should().Be(0);
    }

    [Fact]
    public void ShouldDrawOneOverlappingPoint()
    {
        // Arrange
        var vents = new List<Vent>
        {
            new Vent(new Point(7, 4), new Point(7, 0)),
            new Vent(new Point(7, 4), new Point(7, 6))
        };

        var diagram = new VentDiagram();
        
        // Act
        var map = diagram.Draw(vents);

        // Assert
        map[new Point(7, 4)].Should().Be(1);
        map[new Point(7, 3)].Should().Be(0);
        map[new Point(7, 5)].Should().Be(0);
    }

    [Fact]
    public void ShouldDrawTwoOverlappingPoints()
    {
        // Arrange
        var vents = new List<Vent>
        {
            new Vent(new Point(7, 4), new Point(7, 0)),
            new Vent(new Point(7, 4), new Point(7, 6)),
            new Vent(new Point(0, 4), new Point(9, 4))
        };

        var diagram = new VentDiagram();
        
        // Act
        var map = diagram.Draw(vents);

        // Assert
        map[new Point(7, 4)].Should().Be(2);
        map[new Point(7, 3)].Should().Be(0);
        map[new Point(7, 5)].Should().Be(0);
    }

    [Fact]
    public void ShouldDrawSampleDiagram()
    {
        // Arrange
        var vents = new List<Vent>
        {
            new Vent(new Point(0, 9), new Point(5, 9)),
            new Vent(new Point(8, 0), new Point(0, 8)),
            new Vent(new Point(9, 4), new Point(3, 4)),
            new Vent(new Point(2, 2), new Point(2, 1)),
            new Vent(new Point(7, 0), new Point(7, 4)),
            new Vent(new Point(6, 4), new Point(2, 0)),
            new Vent(new Point(0, 9), new Point(2, 9)),
            new Vent(new Point(3, 4), new Point(1, 4)),
            new Vent(new Point(0, 0), new Point(8, 8)),
            new Vent(new Point(5, 5), new Point(8, 2)),
        };

        var diagram = new VentDiagram();
        
        // Act
        var map = diagram.Draw(vents);

        // Assert
        var sb = new StringBuilder();
        for (var y = 0; y < 10; y++)
        {
            sb.AppendLine();
            for (var x = 0; x < 10; x++)
            {
                if (map.TryGetValue(new Point(x, y), out var count))
                {
                    sb.Append(count);
                }
                else
                {
                    sb.Append(".");
                }
            }
        }
    }
}