using CsvHelper;
using CsvHelper.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Gldd.AdissParser
{
    public class AdissCsvFileParser : IAdissCsvFileParser
    {
        private readonly Configuration csvConfiguration;

        public AdissCsvFileParser()
        {
            csvConfiguration = new Configuration
            {
                Delimiter = ",",
                HasHeaderRecord = false
            };
            csvConfiguration.RegisterClassMap<AdissCsvRecordCsvClassMap>();
        }

        public AdissCsvFile Parse(string filePath)
        {
            using (var streamReader = new StreamReader(File.Open(filePath, FileMode.Open, FileAccess.Read, FileShare.ReadWrite)))
            {
                streamReader.Read(new char[9], 0, 9);
                string projectName = streamReader.ReadLine();

                streamReader.Read(new char[8], 0, 8);
                string permitCode = streamReader.ReadLine();

                streamReader.Read(new char[8], 0, 8);
                string clientName = streamReader.ReadLine();

                streamReader.Read(new char[6], 0, 6);
                int tripNumber = int.Parse(streamReader.ReadLine());

                streamReader.Read(new char[13], 0, 13);
                Scow scow = new ScowParser().ParseFromScowVesselName(streamReader.ReadLine());

                streamReader.Read(new char[17], 0, 17);
                string materialSource = streamReader.ReadLine();

                streamReader.Read(new char[15], 0, 15);
                DateTime transitStart = DateTime.Parse(streamReader.ReadLine());

                streamReader.Read(new char[16], 0, 16);
                DateTime disposalStart = DateTime.Parse(streamReader.ReadLine());

                streamReader.Read(new char[6], 0, 6);
                string note = streamReader.ReadLine();

                streamReader.ReadLine(); // skip empty line 10
                streamReader.ReadLine(); // skip line 11: Local Date/Time,Easting,Northing,Heading,Speed (knots),Aft Draft (ft),Fore Draft (ft),Water Depth (ft),Placement Phase,Hull Status

                List<AdissCsvRecord> records = new CsvReader(streamReader, csvConfiguration).GetRecords<AdissCsvRecord>().ToList();

                IEnumerable<AdissCsvRecord> transitRecords = records.Where(r => r.PlacementPhase == PlacementPhase.Transit);
                AdissCsvRecord firstTransitRecord = transitRecords.First();
                AdissCsvRecord lastTransitRecord = transitRecords.Last();

                IEnumerable<AdissCsvRecord> loadingRecords = records.Where(r => r.PlacementPhase == PlacementPhase.Loading);
                AdissCsvRecord firstLoadingRecord = loadingRecords.First();
                AdissCsvRecord lastLoadingRecord = loadingRecords.Last();

                IEnumerable<AdissCsvRecord> returnRecords = records.Where(r => r.PlacementPhase == PlacementPhase.Return);
                AdissCsvRecord lastReturnRecord = returnRecords.Last();

                IEnumerable<AdissCsvRecord> disposalRecords = records.Where(r => r.PlacementPhase == PlacementPhase.Disposal);
                AdissCsvRecord firstDisposalRecord = disposalRecords.First();
                AdissCsvRecord lastDisposalRecord = disposalRecords.Last();

                IEnumerable<AdissCsvRecord> scowOpenRecords = records.Where(r => r.HullStatus == HullStatus.Open);
                AdissCsvRecord firstScowOpenRecord = scowOpenRecords.First();

                return new AdissCsvFile(
                    projectName: projectName,
                    permitCode: permitCode,
                    clientName: clientName,
                    tripNumber: tripNumber,
                    scow: scow,
                    materialSource: materialSource,
                    transitStart: transitStart,
                    disposalStart: disposalStart,
                    note: note,
                    records: records,
                    averageDraftStartTransitToDisposalArea: firstTransitRecord.AverageDraftInternationalFeet,
                    averageDraftLossDuringTransit: lastTransitRecord.AverageDraftInternationalFeet - firstTransitRecord.AverageDraftInternationalFeet,
                    maximumSpeedDuringTransit: transitRecords.Max(r => r.SpeedKnots),
                    startLoadingDateTime: firstLoadingRecord.LocalDateTime,
                    endLoadingDateTime: lastLoadingRecord.LocalDateTime,
                    startTransitToDisposalAreaDateTime: firstTransitRecord.LocalDateTime,
                    endReturnFromDisposalAreaDateTime: lastReturnRecord.LocalDateTime,
                    totalTransitTime: lastTransitRecord.LocalDateTime - firstTransitRecord.LocalDateTime,
                    startDumpRecord: firstDisposalRecord,
                    endDumpRecord: lastDisposalRecord,
                    scowOpenDateTime: firstScowOpenRecord.LocalDateTime);
            }
        }
    }
}
