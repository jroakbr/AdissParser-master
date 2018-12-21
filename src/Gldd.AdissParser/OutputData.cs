using System;

namespace Gldd.AdissParser
{
    public class OutputData
    {
        public OutputData(int adissLoadNumber, int dredgeLoadNumber, Dredge dredge, string scowVesselName, string tugVesselName, string disposalArea, double? averageDraftLossDuringTransitToDisposalArea, double maximumSpeedDuringTransit, bool? isStartDumpInsideOfBerm, bool isScowOpenViolation, bool isMisDump, bool isEmergencyDump, DateTime startLoadingDateTime, DateTime endLoadingDateTime, DateTime startTransitToDisposalAreaDateTime, double averageDraftStartTransitToDisposalArea, double? averageDraftEnteringDisposalArea, Point2D startDumpXY, DateTime startDumpDateTime, Point2D endDumpXY, DateTime endDumpDateTime, double? averageDraftLeavingTheChannel, DateTime endReturnFromDisposalAreaDateTime, TimeSpan totalTransitDuration, double estimatedLoad, double? startTransitToDisposalAreaDredgeDigX, double? startTransitToDisposalAreaDredgeDigY, double? startTransitToDisposalAreaDredgeDigDepth, double? startTransitToDisposalAreaDredgeDigStation)
        {
            AdissLoadNumber = adissLoadNumber;
            DredgeLoadNumber = dredgeLoadNumber;
            Dredge = dredge;
            ScowVesselName = scowVesselName;
            TugVesselName = tugVesselName;
            DisposalArea = disposalArea;
            AverageDraftLossDuringTransitToDisposalArea = averageDraftLossDuringTransitToDisposalArea;
            MaximumSpeedDuringTransit = maximumSpeedDuringTransit;
            IsStartDumpInsideOfBerm = isStartDumpInsideOfBerm;
            IsScowOpenViolation = isScowOpenViolation;
            IsMisDump = isMisDump;
            IsEmergencyDump = isEmergencyDump;
            StartLoadingDateTime = startLoadingDateTime;
            EndLoadingDateTime = endLoadingDateTime;
            StartTransitToDisposalAreaDateTime = startTransitToDisposalAreaDateTime;
            AverageDraftStartTransitToDisposalArea = averageDraftStartTransitToDisposalArea;
            AverageDraftEnteringDisposalArea = averageDraftEnteringDisposalArea;
            StartDumpXY = startDumpXY;
            StartDumpDateTime = startDumpDateTime;
            EndDumpXY = endDumpXY;
            EndDumpDateTime = endDumpDateTime;
            AverageDraftLeavingTheChannel = averageDraftLeavingTheChannel;
            EndReturnFromDisposalAreaDateTime = endReturnFromDisposalAreaDateTime;
            TotalTransitDuration = totalTransitDuration;
            EstimatedLoad = estimatedLoad;
            StartTransitToDisposalAreaDredgeDigX = startTransitToDisposalAreaDredgeDigX;
            StartTransitToDisposalAreaDredgeDigY = startTransitToDisposalAreaDredgeDigY;
            StartTransitToDisposalAreaDredgeDigDepth = startTransitToDisposalAreaDredgeDigDepth;
            StartTransitToDisposalAreaDredgeDigStation = startTransitToDisposalAreaDredgeDigStation;
        }

        public int AdissLoadNumber { get; }

        public int DredgeLoadNumber { get; }

        public Dredge Dredge { get; }

        public string DredgeName => Dredge.Name;

        public string ScowVesselName { get; }

        public string TugVesselName { get; }

        public string DisposalArea { get; }

        public double? AverageDraftLossDuringTransitToDisposalArea { get; }

        public double MaximumSpeedDuringTransit { get; }

        public bool? IsStartDumpInsideOfBerm { get; }

        public bool IsScowOpenViolation { get; }

        public bool IsMisDump { get; }

        public bool IsEmergencyDump { get; }

        public DateTime StartLoadingDateTime { get; }

        public DateTime EndLoadingDateTime { get; }

        public DateTime StartTransitToDisposalAreaDateTime { get; }

        public double AverageDraftStartTransitToDisposalArea { get; }

        public double? AverageDraftEnteringDisposalArea { get; }

        public Point2D StartDumpXY { get; }

        public DateTime StartDumpDateTime { get; }

        public Point2D EndDumpXY { get; }

        public DateTime EndDumpDateTime { get; }

        public double? AverageDraftLeavingTheChannel { get; }

        public DateTime EndReturnFromDisposalAreaDateTime { get; }

        public TimeSpan TotalTransitDuration { get; }

        public double EstimatedLoad { get; }

        public double? StartTransitToDisposalAreaDredgeDigX { get; }

        public double? StartTransitToDisposalAreaDredgeDigY { get; }

        public double? StartTransitToDisposalAreaDredgeDigDepth { get; }

        public double? StartTransitToDisposalAreaDredgeDigStation { get; }
    }
}