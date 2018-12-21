using System;
using Xunit;

namespace Gldd.AdissParser.Tests
{
    public class ScowParserTests
    {
        [Fact]
        public void ParseFromScowVesselName_Invalid_ThrowOutOfRangeException()
        {
            string scowVesselName = "TestInvalidScowVesselNameMustThrow";

            var parser = new ScowParser();

            Assert.Throws<ArgumentOutOfRangeException>(
                "scowVesselName",
                () => parser.ParseFromScowVesselName(scowVesselName));
        }

        [Theory]
        [MemberData(nameof(ParseFromScowVesselName_Valid_ReturnExpected_Data))]
        public void ParseFromScowVesselName_Valid_ReturnExpected(string scowVesselName, Scow expectedScow)
        {
            var parser = new ScowParser();

            var actualScow = parser.ParseFromScowVesselName(scowVesselName);

            Assert.Equal(expectedScow.Name, actualScow.Name);
            Assert.IsType(expectedScow.GetType(), actualScow);
            Assert.Equal(expectedScow.UllageTable, actualScow.UllageTable);
        }

        public static TheoryData<string, Scow> ParseFromScowVesselName_Valid_ReturnExpected_Data
            => new TheoryData<string, Scow>
            {
                { "GL63", new GlddScow("GL63", ScowSeries._60) },
                { "GL64", new GlddScow("GL64", ScowSeries._60) },
                { "GL65", new GlddScow("GL65", ScowSeries._60) },
                { "GL66", new GlddScow("GL66", ScowSeries._60) },
                { "GL501", new GlddScow("GL501", ScowSeries._500) },
                { "GL502", new GlddScow("GL502", ScowSeries._500) },
                { "GL602", new GlddScow("GL602", ScowSeries._600) },
                { "GL701", new GlddScow("GL701", ScowSeries._700) },
                { "GL702", new GlddScow("GL702", ScowSeries._700) },
                { "MX2015", MarinexScow.MX2015 },
                { "MX2014", MarinexScow.MX2014 },
            };
    }
}