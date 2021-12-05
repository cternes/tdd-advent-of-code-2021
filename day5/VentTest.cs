using System.Drawing;
using FluentAssertions;
using Xunit;

namespace day5
{
    public class VentTest
    {
        [Fact]
        public void ShouldCalculateHorizontalLineWhenStartIsLowerThanEnd()
        {
            // Arrange
            var vent = new Vent(new Point(0, 9), new Point(5, 9));

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(6);

            points[0].X.Should().Be(0);
            points[0].Y.Should().Be(9);
            points[1].X.Should().Be(1);
            points[1].Y.Should().Be(9);
            points[5].X.Should().Be(5);
            points[5].Y.Should().Be(9);
        }

        [Fact]
        public void ShouldCalculateHorizontalLineWhenStartIsHigherThanEnd()
        {
            // Arrange
            var vent = new Vent(new Point(9, 7), new Point(7, 7));

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(3);

            points[0].X.Should().Be(9);
            points[0].Y.Should().Be(7);
            points[1].X.Should().Be(8);
            points[1].Y.Should().Be(7);
            points[2].X.Should().Be(7);
            points[2].Y.Should().Be(7);
        }

        [Fact]
        public void ShouldCalculateVerticalLineWhenStartIsLowerThanEnd()
        {
            // Arrange
            var vent = new Vent(new Point(7, 0), new Point(7, 4));

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(5);

            points[0].X.Should().Be(7);
            points[0].Y.Should().Be(0);
            points[1].X.Should().Be(7);
            points[1].Y.Should().Be(1);
            points[4].X.Should().Be(7);
            points[4].Y.Should().Be(4);
        }

        [Fact]
        public void ShouldCalculateVerticalLineWhenStartIsHigherThanEnd()
        {
            // Arrange
            var vent = new Vent(new Point(7, 4), new Point(7, 0));

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(5);

            points[0].X.Should().Be(7);
            points[0].Y.Should().Be(4);
            points[1].X.Should().Be(7);
            points[1].Y.Should().Be(3);
            points[4].X.Should().Be(7);
            points[4].Y.Should().Be(0);
        }

        [Fact]
        public void ShouldIgnoreNonHorizontalNonVerticalLine()
        {
            // Arrange
            var vent = new Vent(new Point(6, 4), new Point(8, 0));

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(0);
        }

        [Fact]
        public void ShouldCalculateDiagnoalLineIncreasingWhenXyAreIdentical()
        {
            // Arrange
            var vent = new Vent(new Point(1, 1), new Point(3, 3), false);

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(3);

            points[0].X.Should().Be(1);
            points[0].Y.Should().Be(1);
            points[1].X.Should().Be(2);
            points[1].Y.Should().Be(2);
            points[2].X.Should().Be(3);
            points[2].Y.Should().Be(3);
        }

        [Fact]
        public void ShouldCalculateDiagnoalLineDecreasingWhenXyAreIdentical()
        {
            // Arrange
            var vent = new Vent(new Point(3, 3), new Point(1, 1), false);

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(3);

            points[0].X.Should().Be(3);
            points[0].Y.Should().Be(3);
            points[1].X.Should().Be(2);
            points[1].Y.Should().Be(2);
            points[2].X.Should().Be(1);
            points[2].Y.Should().Be(1);
        }

        [Fact]
        public void ShouldCalculateDiagonalLineIncreasing()
        {
            // Arrange
            var vent = new Vent(new Point(9, 7), new Point(7, 9), false);

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(3);

            points[0].X.Should().Be(9);
            points[0].Y.Should().Be(7);
            points[1].X.Should().Be(8);
            points[1].Y.Should().Be(8);
            points[2].X.Should().Be(7);
            points[2].Y.Should().Be(9);
        }

        [Fact]
        public void ShouldCalculateDiagonalLineDecreasing()
        {
            // Arrange
            var vent = new Vent(new Point(7, 9), new Point(9, 7), false);

            // Act
            var points = vent.Points;

            // Assert
            points.Should().HaveCount(3);

            points[0].X.Should().Be(7);
            points[0].Y.Should().Be(9);
            points[1].X.Should().Be(8);
            points[1].Y.Should().Be(8);
            points[2].X.Should().Be(9);
            points[2].Y.Should().Be(7);
        }
    }
}