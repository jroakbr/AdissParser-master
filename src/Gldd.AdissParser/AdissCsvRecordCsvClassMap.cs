using CsvHelper.Configuration;

namespace Gldd.AdissParser
{
    public class AdissCsvRecordCsvClassMap : ClassMap<AdissCsvRecord>
    {
        public AdissCsvRecordCsvClassMap()
        {
            Map(m => m.LocalDateTime).Index(0);
            Map(m => m.Easting).Index(1);
            Map(m => m.Northing).Index(2);
            Map(m => m.HeadingDecimalDegrees).Index(3);
            Map(m => m.SpeedKnots).Index(4);
            Map(m => m.AftDraftInternationalFeet).Index(5);
            Map(m => m.ForeDraftInternationalFeet).Index(6);
            Map(m => m.AftUllageInternationalFeet).Index(7);
            Map(m => m.ForeUllageInternationalFeet).Index(8);
            Map(m => m.WaterDepthInternationalFeet).ConvertUsing(row =>
            {
                string str = row.GetField<string>(9);
                if(str == "N/A")
                {
                    return null;
                }
                else
                {
                    return double.Parse(str);
                }
            });
            Map(m => m.PlacementPhase).Index(10).TypeConverter<PlacementPhaseTypeConverter>();
            Map(m => m.HullStatus).Index(11).TypeConverter<HullStatusTypeConverter>();
        }
    }
}
