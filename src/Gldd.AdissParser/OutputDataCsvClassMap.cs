using CsvHelper.Configuration;

namespace Gldd.AdissParser
{
    public class OutputDataCsvClassMap : ClassMap<OutputData>
    {
        public OutputDataCsvClassMap()
        {
            int i = 0;
            Map(m => m.AdissLoadNumber).Index(i++);
            Map(m => m.DredgeLoadNumber).Index(i++);
            Map(m => m.DredgeName).Index(i++);
            Map(m => m.ScowVesselName).Index(i++);
            Map(m => m.TugVesselName).Index(i++);
            Map(m => m.DisposalArea).Index(i++);
            Map(m => m.AverageDraftLossDuringTransitToDisposalArea).Index(i++);
            Map(m => m.MaximumSpeedDuringTransit).Index(i++);
            Map(m => m.IsStartDumpInsideOfBerm).Index(i++);
            Map(m => m.IsScowOpenViolation).Index(i++);
            Map(m => m.IsMisDump).Index(i++);
            Map(m => m.IsEmergencyDump).Index(i++);
            Map(m => m.StartLoadingDateTime).Index(i++);
            Map(m => m.EndLoadingDateTime).Index(i++);
            Map(m => m.StartTransitToDisposalAreaDateTime).Index(i++);
            Map(m => m.AverageDraftStartTransitToDisposalArea).Index(i++);
            Map(m => m.AverageDraftLeavingTheChannel).Index(i++);
            Map(m => m.AverageDraftEnteringDisposalArea).Index(i++);
            Map(m => m.StartDumpXY.X).Name("StartDumpX").Index(i++);
            Map(m => m.StartDumpXY.Y).Name("StartDumpY").Index(i++);
            Map(m => m.StartDumpDateTime).Index(i++);
            Map(m => m.EndDumpXY.X).Name("EndDumpX").Index(i++);
            Map(m => m.EndDumpXY.Y).Name("EndDumpY").Index(i++);
            Map(m => m.EndDumpDateTime).Index(i++);
            Map(m => m.EndReturnFromDisposalAreaDateTime).Index(i++);
            Map(m => m.TotalTransitDuration).Index(i++);
            Map(m => m.EstimatedLoad).Index(i++);
            Map(m => m.StartTransitToDisposalAreaDredgeDigX).Index(i++);
            Map(m => m.StartTransitToDisposalAreaDredgeDigY).Index(i++);
            Map(m => m.StartTransitToDisposalAreaDredgeDigDepth).Index(i++);
            Map(m => m.StartTransitToDisposalAreaDredgeDigStation).Index(i++);
        }
    }
}