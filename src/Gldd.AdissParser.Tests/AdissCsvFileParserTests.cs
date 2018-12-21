using System;
using System.Linq;
using Xunit;

namespace Gldd.AdissParser.Tests
{
    public class AdissCsvFileParserTests
    {
        [Fact]
        public void Parse_DemoFile_ReturnExpected()
        {
            AdissCsvFile adissCsvFile = new AdissCsvFileParser().Parse(@"Files\Unknown_GL702_Trip1.csv");

            Assert.Equal("2018 Post 45 Charleston Entrance Channel Maintenance and New Work Dredging", adissCsvFile.ProjectName);
            Assert.Equal("W912HP-18-C-0001", adissCsvFile.PermitCode);
            Assert.Equal("Great Lakes Dredge & Dock Co.", adissCsvFile.ClientName);
            Assert.Equal(1, adissCsvFile.TripNumber);
            Assert.Equal("GL702", adissCsvFile.Scow.Name);
            Assert.Equal("UNKNOWN", adissCsvFile.MaterialSource);
            Assert.Equal(new DateTime(2018, 5, 1, 6, 45, 51), adissCsvFile.TransitStart);
            Assert.Equal(new DateTime(2018, 5, 1, 8, 21, 18), adissCsvFile.DisposalStart);
            Assert.Equal("Coordinates are in NAD 1983 StatePlane South Carolina FIPS 3900 Feet", adissCsvFile.Note);

            AdissCsvRecord firstRecord = adissCsvFile.Records.First();
            Assert.Equal(new DateTime(2018, 5, 1, 1, 10, 51), firstRecord.LocalDateTime);
            Assert.Equal(2400927.97, firstRecord.Easting);
            Assert.Equal(306961.23, firstRecord.Northing);
            Assert.Equal(119.28, firstRecord.HeadingDecimalDegrees);
            Assert.Equal(0, firstRecord.SpeedKnots);
            Assert.Equal(5.46, firstRecord.AftDraftInternationalFeet);
            Assert.Equal(2.93, firstRecord.ForeDraftInternationalFeet);
            Assert.Equal(27.31, firstRecord.AftUllageInternationalFeet);
            Assert.Equal(29.03, firstRecord.ForeUllageInternationalFeet);
            Assert.Null(firstRecord.WaterDepthInternationalFeet);
            Assert.Equal(PlacementPhase.Loading, firstRecord.PlacementPhase);
            Assert.Equal(HullStatus.Closed, firstRecord.HullStatus);
        }
    }
}
