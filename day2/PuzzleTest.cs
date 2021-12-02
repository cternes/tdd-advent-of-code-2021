using System.Diagnostics;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using FileHandling;
using FluentAssertions;
using Xunit;

namespace day2;

public class PuzzleTest
{
    [Fact]
    public async Task ShouldSolvePuzzle1()
    {
        // Arrange
        var lines = await FileReader.ReadFile("Testdata/input.txt");
        var commands = new CommandProducer().ReadCommands(lines);
        var submarine = new Submarine();
        
        // Act
        submarine.Move(commands);

        // Assert
        submarine.MultipliedPosition.Should().BeGreaterThan(0);
        Trace.TraceInformation($"{submarine.MultipliedPosition}");
    }

    [Fact]
    public async Task ShouldSolvePuzzle2()
    {
        // Arrange
        var lines = await FileReader.ReadFile("Testdata/input.txt");
        var commands = new CommandProducer().ReadCommands(lines);
        var submarine = new AimingSubmarine();
        
        // Act
        submarine.Move(commands);

        // Assert
        submarine.MultipliedPosition.Should().BeGreaterThan(0);
        Trace.TraceInformation($"{submarine.MultipliedPosition}");
    }
}