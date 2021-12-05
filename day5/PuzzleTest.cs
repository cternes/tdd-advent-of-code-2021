using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Threading.Tasks;
using day5;
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
        var vents = VentProducer.CreateVents(lines);
        
        // Act
        var map = new VentDiagram().Draw(vents);
        var count = map.Values.Count(i => i >= 2);

        // Assert
        count.Should().BeGreaterThan(0);
        Trace.TraceInformation($"{count}");
    }

    [Fact]
    public async Task ShouldSolvePuzzle2()
    {
        // Arrange
        var lines = await FileReader.ReadFile("Testdata/input.txt");
        var vents = VentProducer.CreateVents(lines, false);
        
        // Act
        var map = new VentDiagram().Draw(vents);
        var count = map.Values.Count(i => i >= 2);

        // Assert
        count.Should().BeGreaterThan(0);
        Trace.TraceInformation($"{count}");
    }
    
}