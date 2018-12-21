using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gldd.AdissParser
{
    public class DrgFileParser : IDrgFileParser
    {
        private readonly Configuration csvConfiguration;

        public DrgFileParser()
        {
            csvConfiguration = new Configuration();
            csvConfiguration.RegisterClassMap<DrgRecordCsvClassMap>();
        }

        public DrgRecord ParseNearestRecordByDateTime(IEnumerable<string> filePaths, DateTime dateTime, TimeSpan margin)
        {
            return filePaths
                .Select(f => ParseNearestRecordByDateTime(f, dateTime, margin))
                .FirstOrDefault(r => r != null);
        }

        private DrgRecord ParseNearestRecordByDateTime(string filepath, DateTime dateTime, TimeSpan margin)
        {
            var config = new Configuration();

            config.RegisterClassMap<DrgRecordCsvClassMap>();

            using (var streamReader = new StreamReader(filepath))
            {
                return new CsvReader(streamReader, config)
                    .GetRecords<DrgRecord>()
                    .FirstOrDefault(r => r.DateTime >= dateTime && r.DateTime <= dateTime.Add(margin));
            }
        }
    }
}
