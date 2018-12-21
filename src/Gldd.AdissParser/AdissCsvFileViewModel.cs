using System;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Gldd.AdissParser
{
    public class AdissCsvFileViewModel
    {
        private readonly AdissCsvFile adissCsvFile;

        public AdissCsvFileViewModel(AdissCsvFile adissCsvFile)
        {
            this.adissCsvFile = adissCsvFile;
        }

        [PropertyOrder(0)]
        public int TripNumber => adissCsvFile.TripNumber;

        [PropertyOrder(1)]
        public string ScowVesselName => adissCsvFile.Scow.Name;

        [PropertyOrder(2)]
        public double AverageDraftStartTransitToDisposalArea => adissCsvFile.AverageDraftStartTransitToDisposalArea;

        [PropertyOrder(3)]
        public double AverageDraftLossDuringTransit => adissCsvFile.AverageDraftLossDuringTransit;

        [PropertyOrder(4)]
        public double MaximumSpeedDuringTransit => adissCsvFile.MaximumSpeedDuringTransit;

        [PropertyOrder(5)]
        public DateTime StartLoadingDateTime => adissCsvFile.StartLoadingDateTime;

        [PropertyOrder(6)]
        public DateTime EndLoadingDateTime => adissCsvFile.EndLoadingDateTime;

        [PropertyOrder(7)]
        public DateTime StartTransitToDisposalAreaDateTime => adissCsvFile.StartTransitToDisposalAreaDateTime;

        [PropertyOrder(8)]
        public DateTime EndReturnFromDisposalAreaDateTime => adissCsvFile.EndReturnFromDisposalAreaDateTime;

        [PropertyOrder(9)]
        public TimeSpan TotalTransitTime => adissCsvFile.TotalTransitTime;

        [PropertyOrder(10)]
        public Point2D StartDumpXY => adissCsvFile.StartDumpRecord.XYCoordinate;

        [PropertyOrder(11)]
        public DateTime StartDumpDateTime => adissCsvFile.StartDumpRecord.LocalDateTime;

        [PropertyOrder(12)]
        public Point2D EndDumpXY => adissCsvFile.EndDumpRecord.XYCoordinate;

        [PropertyOrder(13)]
        public DateTime EndDumpDateTime => adissCsvFile.EndDumpRecord.LocalDateTime;

        [PropertyOrder(14)]
        public DateTime ScowOpenDateTime => adissCsvFile.ScowOpenDateTime;
    }
}
