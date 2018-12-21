using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace Gldd.AdissParser
{
    public class PlacementPhaseTypeConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            switch (text.ToUpper())
            {
                case "IDLE":
                    return PlacementPhase.Idle;
                case "LOADING":
                    return PlacementPhase.Loading;
                case "TRANSIT":
                    return PlacementPhase.Transit;
                case "DISPOSAL":
                    return PlacementPhase.Disposal;
                case "RETURN":
                    return PlacementPhase.Return;
                case "OFFSITE":
                    return PlacementPhase.Offsite;
                default:
                    throw new ArgumentOutOfRangeException(nameof(text), text, $"Cannot parse {text} as type {nameof(PlacementPhase)}");
            }
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}
