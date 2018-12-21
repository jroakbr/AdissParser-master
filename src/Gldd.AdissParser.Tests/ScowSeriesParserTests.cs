using System;
using Xunit;

namespace Gldd.AdissParser.Tests
{
    public class ScowSeriesParserTests
    {
        [Fact]
        public void ParseFromGlddScowVesselNumber_Invalid_ThrowOutOfRangeException()
        {
            int glddScowVesselNumber = 0;

            var parser = new ScowSeriesParser();

            Assert.Throws<ArgumentOutOfRangeException>(
                "glddScowVesselNumber", 
                () => parser.ParseFromGlddScowVesselNumber(glddScowVesselNumber));
        }

        [Theory]
        [MemberData(nameof(ParseFromGlddScowVesselNumber_Valid_ReturnExpected_Data))]
        public void ParseFromGlddScowVesselNumber_Valid_ReturnExpected(
            int scowSeriesNumber,
            ScowSeries expectedScowSeries)
        {
            var parser = new ScowSeriesParser();

            var actualScowSeries = parser.ParseFromGlddScowVesselNumber(scowSeriesNumber);

            Assert.Same(expectedScowSeries, actualScowSeries);
        }

        public static TheoryData<int, ScowSeries> ParseFromGlddScowVesselNumber_Valid_ReturnExpected_Data
            => new TheoryData<int, ScowSeries>
            {
                { 63, ScowSeries._60 },
                { 64, ScowSeries._60 },
                { 65, ScowSeries._60 },
                { 66, ScowSeries._60 },
                { 501, ScowSeries._500 },
                { 502, ScowSeries._500 },
                { 602, ScowSeries._600 },
                { 701, ScowSeries._700 },
                { 702, ScowSeries._700 },
            };
    }
}
