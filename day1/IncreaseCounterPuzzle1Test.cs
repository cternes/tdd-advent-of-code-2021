using System.Collections.Generic;
using System.Diagnostics;
using System.Threading.Tasks;
using FileHandling;
using FluentAssertions;
using Xunit;

namespace day1;

public class IncreaseCounterPuzzle1Test
{
    [Fact]
    public void ShouldIncrease3TimesWhenValuesOnlyIncreasing()
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
        var result = new IncreaseCounter().Count(input);

        // Assert
        result.Should().Be(3);
    }

    [Fact]
    public void ShouldIncrease2TimesWhenValuesAreIncreasingAndDecreasing()
    {
        // Arrange
        var input = new List<int>
        {
            199,
            200,
            199,
            200
        };

        // Act
        var result = new IncreaseCounter().Count(input);

        // Assert
        result.Should().Be(2);
    }

    [Fact]
    public async Task ShouldIncrease7TimesWhenValuesComeFromSampleData()
    {
        // Arrange
        var lines = await FileReader.ReadFileAsInt("Testdata/sampleInput.txt");

        // Act
        var result = new IncreaseCounter().Count(lines);        

        // Assert
        result.Should().Be(7);
    }

    [Fact]
    public async Task ShouldGiveSolutionToPuzzle1()
    {
        // Arrange
        var lines = await FileReader.ReadFileAsInt("Testdata/input.txt");

        // Act
        var result = new IncreaseCounter().Count(lines);        

        // Assert
        result.Should().BeGreaterThan(1);
        Trace.TraceInformation($"{result}");
    }
}