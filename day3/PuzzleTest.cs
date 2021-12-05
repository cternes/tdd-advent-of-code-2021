using System.Diagnostics;
using System.Threading.Tasks;
using FileHandling;
using FluentAssertions;
using Xunit;

namespace day3;

public class PuzzleTest
{
    [Fact]
    public async Task ShouldSolvePuzzle1()
    {
        // Arrange
        var lines = await FileReader.ReadFile("Testdata/input.txt");

        // Act
        var gammaRateString = BitCounter.FindGammaRate(lines);
        var epsilonRateString = BitCounter.FindEpsilonRate(lines);
        
        var gammaRate = BitCounter.ToInt(gammaRateString);
        var epsilonRate = BitCounter.ToInt(epsilonRateString);

        // Assert
        var result = gammaRate * epsilonRate;
        result.Should().BeGreaterThan(0);

        Trace.TraceInformation($"{result}");
    }
}