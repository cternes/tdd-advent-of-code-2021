using System.Collections.Generic;
using System.Linq;
using FluentAssertions;
using Xunit;

namespace day2;

public class CommandProducerTest
{
    [Fact]
    public void ShouldReadForwardCommand()
    {
        // Arrange
        var lines = new List<string>
        {
            "forward 5"
        };

        // Act
        var commands = new CommandProducer().ReadCommands(lines);

        // Assert
        var command = commands.First();
        command.Direction.Should().Be(Direction.forward);
        command.Value.Should().Be(5);
    }

    [Fact]
    public void ShouldReadListOfCommands()
    {
        // Arrange
        var lines = new List<string>
        {
            "forward 5",
            "down 10",
            "up 8"
        };

        // Act
        var commands = new CommandProducer().ReadCommands(lines);

        // Assert
        var first = commands.First();
        first.Direction.Should().Be(Direction.forward);
        first.Value.Should().Be(5);

        var second = commands[1];
        second.Direction.Should().Be(Direction.down);
        second.Value.Should().Be(10);

        var third = commands[2];
        third.Direction.Should().Be(Direction.up);
        third.Value.Should().Be(8);
    }
}