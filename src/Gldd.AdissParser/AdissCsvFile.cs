using System;
using System.Collections.Generic;

namespace Gldd.AdissParser
{
    public class AdissCsvFile
    {
        public AdissCsvFile(string projectName, string permitCode, string clientName, int tripNumber, Scow scow, string materialSource, DateTime transitStart, DateTime disposalStart, string note, IEnumerable<AdissCsvRecord> records, double averageDraftStartTransitToDisposalArea, double averageDraftLossDuringTransit, double maximumSpeedDuringTransit, DateTime startLoadingDateTime, DateTime endLoadingDateTime, DateTime startTransitToDisposalAreaDateTime, DateTime endReturnFromDisposalAreaDateTime, TimeSpan totalTransitTime, AdissCsvRecord startDumpRecord, AdissCsvRecord endDumpRecord, DateTime scowOpenDateTime)
        {
            ProjectName = projectName;
            PermitCode = permitCode;
            ClientName = clientName;
            TripNumber = tripNumber;
            Scow = scow;
            MaterialSource = materialSource;
            TransitStart = transitStart;
            DisposalStart = disposalStart;
            Note = note;
            Records = records;
            AverageDraftStartTransitToDisposalArea = averageDraftStartTransitToDisposalArea;
            AverageDraftLossDuringTransit = averageDraftLossDuringTransit;
            MaximumSpeedDuringTransit = maximumSpeedDuringTransit;
            StartLoadingDateTime = startLoadingDateTime;
            EndLoadingDateTime = endLoadingDateTime;
            StartTransitToDisposalAreaDateTime = startTransitToDisposalAreaDateTime;
            EndReturnFromDisposalAreaDateTime = endReturnFromDisposalAreaDateTime;
            TotalTransitTime = totalTransitTime;
            StartDumpRecord = startDumpRecord;
            EndDumpRecord = endDumpRecord;
            ScowOpenDateTime = scowOpenDateTime;
        }

        public string ProjectName { get; }

        public string PermitCode { get; }

        public string ClientName { get; }

        public int TripNumber { get; }

        public Scow Scow { get; }

        public string MaterialSource { get; }

        public DateTime TransitStart { get; }

        public DateTime DisposalStart { get; }

        public string Note { get; }

        public IEnumerable<AdissCsvRecord> Records { get; }

        public double AverageDraftStartTransitToDisposalArea { get; }

        public double LookupEstimatedLoadSize() => Scow.UllageTable.LookupVolume(AverageDraftStartTransitToDisposalArea);

        public double AverageDraftLossDuringTransit { get; }

        public double MaximumSpeedDuringTransit { get; }

        public DateTime StartLoadingDateTime { get; }

        public DateTime EndLoadingDateTime { get; }

        public DateTime StartTransitToDisposalAreaDateTime { get; }

        public DateTime EndReturnFromDisposalAreaDateTime { get; }

        public TimeSpan TotalTransitTime { get; }

        public AdissCsvRecord StartDumpRecord { get; }

        public AdissCsvRecord EndDumpRecord { get; }

        public DateTime ScowOpenDateTime { get; }
    }
}