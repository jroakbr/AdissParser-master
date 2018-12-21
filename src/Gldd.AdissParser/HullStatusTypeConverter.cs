using CsvHelper;
using CsvHelper.Configuration;
using CsvHelper.TypeConversion;
using System;

namespace Gldd.AdissParser
{
    public class HullStatusTypeConverter : ITypeConverter
    {
        public object ConvertFromString(string text, IReaderRow row, MemberMapData memberMapData)
        {
            switch (text)
            {
                case "CLOSED":
                    return HullStatus.Closed;
                case "OPEN":
                    return HullStatus.Open;
                case "UNKNOWN":
                    return HullStatus.Unknown;
                default:
                    throw new ArgumentOutOfRangeException(nameof(text), text, $"Cannot parse {text} as type {nameof(HullStatus)}");
            }
        }

        public string ConvertToString(object value, IWriterRow row, MemberMapData memberMapData)
        {
            throw new NotImplementedException();
        }
    }
}