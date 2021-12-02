using System.Collections.Generic;
using FluentAssertions;
using Xunit;

namespace day2;

public class AimingSubmarineTest
{
    [Fact]
    public void ShouldMoveForward()
    {
        // Arrange
        var commands = new List<Command>
        {
            new Command(Direction.forward, 5)
        };

        var submarine = new AimingSubmarine();

        // Act
        submarine.Move(commands);

        // Assert
        submarine.HorizontalPosition.Should().Be(5);
        submarine.Depth.Should().Be(0);
        submarine.Aim.Should().Be(0);
    }

    [Fact]
    public void ShouldMoveDown()
    {
        // Arrange
        var commands = new List<Command>
        {
            new Command(Direction.down, 5)
        };

        var submarine = new AimingSubmarine();

        // Act
        submarine.Move(commands);

        // Assert
        submarine.HorizontalPosition.Should().Be(0);
        submarine.Depth.Should().Be(0);
        submarine.Aim.Should().Be(5);
    }

    [Fact]
    public void ShouldMoveDownForward()
    {
        // Arrange
        var commands = new List<Command>
        {
            new Command(Direction.down, 5),
            new Command(Direction.forward, 8)
        };

        var submarine = new AimingSubmarine();

        // Act
        submarine.Move(commands);

        // Assert
        submarine.HorizontalPosition.Should().Be(8);
        submarine.Depth.Should().Be(40);
        submarine.Aim.Should().Be(5);
    }

    [Fact]
    public void ShouldFollowSamplePath()
    {
        // Arrange
        var commands = new List<Command>
        {
            new Command(Direction.forward, 5),
            new Command(Direction.down, 5),
            new Command(Direction.forward, 8),
            new Command(Direction.up, 3),
            new Command(Direction.down, 8),
            new Command(Direction.forward, 2)
        };

        var submarine = new AimingSubmarine();

        // Act
        submarine.Move(commands);

        // Assert
        submarine.Aim.Should().Be(10);
        submarine.HorizontalPosition.Should().Be(15);
        submarine.Depth.Should().Be(60);
    }

    [Fact]
    public void ShouldCalculateMultipliedPosition()
    {
        // Arrange
        var commands = new List<Command>
        {
            new Command(Direction.forward, 5),
            new Command(Direction.down, 5),
            new Command(Direction.forward, 8),
            new Command(Direction.up, 3),
            new Command(Direction.down, 8),
            new Command(Direction.forward, 2)
        };

        var submarine = new AimingSubmarine();

        // Act
        submarine.Move(commands);

        // Assert
        submarine.MultipliedPosition.Should().Be(900);
    }
}