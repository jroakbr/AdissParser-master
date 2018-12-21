using CsvHelper;
using CsvHelper.Configuration;
using System.IO;

namespace Gldd.AdissParser
{
    public class OutputDataCsvFileWriter : IOutputDataCsvFileWriter
    {
        private readonly Configuration csvConfiguration;

        public OutputDataCsvFileWriter()
        {
            csvConfiguration = new Configuration
            {
                Delimiter = ",",
                HasHeaderRecord = true
            };
            csvConfiguration.RegisterClassMap<OutputDataCsvClassMap>();
        }

        public void Write(string filePath, OutputData outputData)
        {
            using (var streamWriter = new StreamWriter(filePath))
            using (var csvWriter = new CsvWriter(streamWriter, csvConfiguration))
            {
                csvWriter.WriteRecords(new[] { outputData });
            }
        }
    }
}
