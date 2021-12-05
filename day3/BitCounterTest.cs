using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using FluentAssertions;
using Xunit;

namespace day3
{
    public class BitCounterTest
    {
        [Theory]
        [InlineData(0, "1")]
        [InlineData(1, "0")]
        [InlineData(2, "1")]
        [InlineData(3, "1")]
        [InlineData(4, "0")]
        public void ShouldGetCommonBit(int position, string expected)
        {
            // Arrange
            var lines = new List<string>
            {
                "00100",
                "11110",
                "10110"
            };

            // Act
            var mostCommon = BitCounter.FindMostCommonBit(position, lines);

            // Assert
            mostCommon.Should().Be(expected);
        }

        [Theory]
        [InlineData(0, "0")]
        [InlineData(1, "1")]
        [InlineData(2, "0")]
        [InlineData(3, "0")]
        [InlineData(4, "1")]
        public void ShouldGetLeastBit(int position, string expected)
        {
            // Arrange
            var lines = new List<string>
            {
                "00100",
                "11110",
                "10110"
            };

            // Act
            var mostCommon = BitCounter.FindLeastCommonBit(position, lines);

            // Assert
            mostCommon.Should().Be(expected);
        }

        [Fact]
        public void ShouldFindGammaRate()
        {
            // Arrange
            var lines = new List<string>
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            // Act
            var mostCommon = BitCounter.FindGammaRate(lines);

            // Assert
            mostCommon.Should().Be("10110");
        }

        [Fact]
        public void ShouldFindEpsilonRate()
        {
            // Arrange
            var lines = new List<string>
            {
                "00100",
                "11110",
                "10110",
                "10111",
                "10101",
                "01111",
                "00111",
                "11100",
                "10000",
                "11001",
                "00010",
                "01010"
            };

            // Act
            var mostCommon = BitCounter.FindEpsilonRate(lines);

            // Assert
            mostCommon.Should().Be("01001");
        }

        [Theory]
        [InlineData("10110", 22)]
        [InlineData("01001", 9)]
        public void ShouldConvertStringToInt(string binary, int expected)
        {
            // Act
            var result = BitCounter.ToInt(binary);

            // Assert
            result.Should().Be(expected);
        }
    }

    public class BitCounter
    {
        public static int ToInt(string binary)
        {
            return Convert.ToInt32(binary, 2);
        }

        public static string FindMostCommonBit(int position, List<string> lines)
        {
            var bit = lines.Select(i => i[position])
                .ToList();

            var zeroCount = bit.Count(i => i == '0');
            var oneCount = bit.Count(i => i == '1');

            if (zeroCount > oneCount)
            {
                return "0";
            }

            return "1";
        }

        public static string FindLeastCommonBit(int position, List<string> lines)
        {
            var bit = FindMostCommonBit(position, lines);
            return bit == "1" ? "0" : "1";
        }

        public static string FindGammaRate(List<string> lines)
        {
            return FindRate(lines, FindMostCommonBit);
        }

        public static string FindEpsilonRate(List<string> lines)
        {
            return FindRate(lines, FindLeastCommonBit);
        }

        private static string FindRate(List<string> lines, Func<int, List<string>, string> findMethod)
        {
            var epsilonRate = new StringBuilder();
            for (var i = 0; i < lines[0].Length; i++)
            {
                var bit = findMethod(i, lines);
                epsilonRate.Append(bit);
            }

            return epsilonRate.ToString();
        }
    }
}