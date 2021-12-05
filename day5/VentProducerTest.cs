using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace day5;

public class VentProducerTest
{
    [Fact]
    public void ShouldProduceVent()
    {
        // Arrange
        var lines = new List<string>()
        {
            "0,9 -> 5,9"
        };

        // Act
        var vents = VentProducer.CreateVents(lines);

        // Assert
        vents.Should().HaveCount(1);
        vents.First().Start.Should().Be(new Point(0, 9));
        vents.First().End.Should().Be(new Point(5, 9));
    }
}