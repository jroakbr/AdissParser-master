using CsvHelper.Configuration;

namespace Gldd.AdissParser
{
    public class DrgRecordCsvClassMap : ClassMap<DrgRecord>
    {
        public DrgRecordCsvClassMap()
        {
            Map(r => r.Time).Index(0).Name("[Time 24hr hh:mm:ss] ");
            Map(r => r.Date).Index(1).Name(" [Date dd/mm/yy 27/1/98] ").TypeConverterOption.Format("dd/MM/yy");
            Map(r => r.BucketX).Index(4).Name(" [Easting of Bucket] ");
            Map(r => r.BucketY).Index(5).Name(" [Northing of Bucket] ");
            Map(r => r.BucketStation).Index(8).Name(" [Station of Bucket] ");
            Map(r => r.BucketDepth).Index(16).Name(" [Bucket Depth Ft.] ");
        }
    }
}
