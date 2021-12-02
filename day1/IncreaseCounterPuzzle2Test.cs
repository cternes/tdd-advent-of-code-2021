using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using FileHandling;
using FluentAssertions;
using Xunit;

namespace day1;

public class IncreaseCounterPuzzle2Test
{
    [Fact]
    public void ShouldIncrease1TimesWhenValuesOnlyIncreasing()
    {
        // Arrange
        var input = new List<int>
        {
            199,
            200,
            208,
            210
        };

        // Act
        var result = new IncreaseCounter().CountWithSlidingWindows(input);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void ShouldIncrease1TimesWhenValuesIncreasingAndEqualSum()
    {
        // Arrange
        var input = new List<int>
        {
            199,
            200,
            208,
            210,
            200
        };

        // Act
        var result = new IncreaseCounter().CountWithSlidingWindows(input);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public void ShouldIncrease1TimesWhenValuesIncreasingAndDecreasing()
    {
        // Arrange
        var input = new List<int>
        {
            199,
            200,
            208,
            210,
            200,
            207
        };

        // Act
        var result = new IncreaseCounter().CountWithSlidingWindows(input);

        // Assert
        result.Should().Be(1);
    }

    [Fact]
    public async Task ShouldGiveSolutionToPuzzle2()
    {
        // Arrange
        var lines = await FileReader.ReadFileAsInt("Testdata/input.txt");

        // Act
        var result = new IncreaseCounter().CountWithSlidingWindows(lines);

        // Assert
        result.Should().BeGreaterThan(1);
        Trace.TraceInformation($"{result}");
    }

}