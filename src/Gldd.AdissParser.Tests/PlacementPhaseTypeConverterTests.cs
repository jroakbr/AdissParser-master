using Xunit;

namespace Gldd.AdissParser.Tests
{
    public class PlacementPhaseTypeConverterTests
    {
        [Fact]
        public void ConvertFromString_LowerCase_MustParse()
        {
            var converter = new PlacementPhaseTypeConverter();

            PlacementPhase phase = (PlacementPhase)converter.ConvertFromString("Offsite", null, null);

            Assert.Equal(PlacementPhase.Offsite, phase);
        }
    }
}