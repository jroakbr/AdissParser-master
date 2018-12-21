using System.Collections.Generic;
using System.Linq;

namespace Gldd.AdissParser
{
    public class OutputDataGenerator : IOutputDataGenerator
    {
        ICharlestonDeepening2Service charlestonDeepening2Service;
        public OutputDataGenerator(ICharlestonDeepening2Service charlestonDeepening2Service)
        {
            this.charlestonDeepening2Service = charlestonDeepening2Service;
        }

        public OutputData Generate(UserInput userInput, DredgeRecord dredgeRecord, AdissCsvFile adissCsvFile)
        {
            IEnumerable<AdissCsvRecord> transitRecords = adissCsvFile.Records.Where(r => r.PlacementPhase == PlacementPhase.Transit);
            IEnumerable<AdissCsvRecord> reversedTransitRecords = transitRecords.Reverse();

            AdissCsvRecord firstRecordExitedTheChannelBeforeGoingStraightToDisposal = reversedTransitRecords
                .TakeWhile(r => !charlestonDeepening2Service.IsWithinChannel(r.XYCoordinate))
                .Last();

            double? averageDraftLeavingTheChannel = null;
            if (!ReferenceEquals(firstRecordExitedTheChannelBeforeGoingStraightToDisposal, transitRecords.First())) //true if scow was outside the channel the whole time
            {
                averageDraftLeavingTheChannel = firstRecordExitedTheChannelBeforeGoingStraightToDisposal.AverageDraftInternationalFeet;
            }

            AdissCsvRecord firstRecordInsideDisposalArea = adissCsvFile.Records.FirstOrDefault(r => userInput.DisposalArea.Polygon2D.DoesBound(r.XYCoordinate));
            double? averageDraftEnteringDisposalArea = null;
            double? averageDraftLossDuringTransitToDisposalArea = null;
            if(firstRecordInsideDisposalArea != null)
            {
                averageDraftEnteringDisposalArea = firstRecordInsideDisposalArea.AverageDraftInternationalFeet;
                averageDraftLossDuringTransitToDisposalArea = firstRecordInsideDisposalArea.AverageDraftInternationalFeet - transitRecords.First().AverageDraftInternationalFeet;
            }

            bool? isStartDumpInsideOfBerm = null;
            if (charlestonDeepening2Service.ShouldDumpInBermArea(userInput.DisposalArea))
            {
                isStartDumpInsideOfBerm = charlestonDeepening2Service.IsWithinBermArea(adissCsvFile.StartDumpRecord.XYCoordinate);
            }

            bool isMisDump = !userInput.DisposalArea.Polygon2D.DoesBound(adissCsvFile.StartDumpRecord.XYCoordinate);

            bool isScowOpenViolation = adissCsvFile.Records
                    .Where(r => r.HullStatus == HullStatus.Open || r.PlacementPhase == PlacementPhase.Disposal)
                    .Any(r => !userInput.DisposalArea.Polygon2D.DoesBound(r.XYCoordinate));

            return new OutputData(
                adissLoadNumber: adissCsvFile.TripNumber,
                dredgeLoadNumber: userInput.DredgeLoadNumber,
                dredge: userInput.Dredge,
                scowVesselName: adissCsvFile.Scow.Name,
                tugVesselName: userInput.TugVesselName,
                disposalArea: userInput.DisposalArea.Name,
                averageDraftLossDuringTransitToDisposalArea: averageDraftLossDuringTransitToDisposalArea,
                maximumSpeedDuringTransit: adissCsvFile.MaximumSpeedDuringTransit,
                isStartDumpInsideOfBerm: isStartDumpInsideOfBerm,
                isScowOpenViolation: isScowOpenViolation,
                isMisDump: isMisDump,
                isEmergencyDump: userInput.IsEmergencyDump,
                startLoadingDateTime: adissCsvFile.StartLoadingDateTime,
                endLoadingDateTime: adissCsvFile.EndLoadingDateTime,
                startTransitToDisposalAreaDateTime: adissCsvFile.StartTransitToDisposalAreaDateTime,
                averageDraftStartTransitToDisposalArea: adissCsvFile.AverageDraftStartTransitToDisposalArea,
                averageDraftEnteringDisposalArea: averageDraftEnteringDisposalArea,
                startDumpXY: adissCsvFile.StartDumpRecord.XYCoordinate,
                startDumpDateTime: adissCsvFile.StartDumpRecord.LocalDateTime,
                endDumpXY: adissCsvFile.EndDumpRecord.XYCoordinate,
                endDumpDateTime: adissCsvFile.EndDumpRecord.LocalDateTime,
                averageDraftLeavingTheChannel: averageDraftLeavingTheChannel,
                endReturnFromDisposalAreaDateTime: adissCsvFile.EndReturnFromDisposalAreaDateTime,
                totalTransitDuration: adissCsvFile.TotalTransitTime,
                estimatedLoad: adissCsvFile.LookupEstimatedLoadSize(),
                startTransitToDisposalAreaDredgeDigX: dredgeRecord?.X,
                startTransitToDisposalAreaDredgeDigY: dredgeRecord?.Y,
                startTransitToDisposalAreaDredgeDigDepth: dredgeRecord?.Depth,
                startTransitToDisposalAreaDredgeDigStation: dredgeRecord?.Station);
        }
    }
}
