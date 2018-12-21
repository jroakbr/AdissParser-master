using Xunit;

namespace Gldd.AdissParser.Tests
{
    public class Polygon2DTests
    {
        [Theory]
        [InlineData(0, 0, true)]
        [InlineData(2, 2, false)]
        [InlineData(1, 1, true)]
        public void DoesBound_ReturnExpected(double x, double y, bool expectedDoesBound)
        {
            var polygon = new Polygon2D(new[]
            {
                new Point2D(-1, -1),
                new Point2D(-1, 1),
                new Point2D(1, 1),
                new Point2D(1, -1)
            });

            Assert.Equal(expectedDoesBound, polygon.DoesBound(new Point2D(x, y)));
        }
    }
}