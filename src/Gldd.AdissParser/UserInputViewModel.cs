using Prism.Mvvm;
using System.Linq;
using Xceed.Wpf.Toolkit.PropertyGrid.Attributes;

namespace Gldd.AdissParser
{
    public class UserInputViewModel : BindableBase
    {
        private int dredgeLoadNumber;

        [PropertyOrder(0)]
        public int DredgeLoadNumber { get => dredgeLoadNumber; set => SetProperty(ref dredgeLoadNumber, value); }

        private Dredge dredge = Dredge.Carolina;
        [PropertyOrder(1)]
        [ItemsSource(typeof(DredgeItemsSource))]
        public Dredge Dredge { get => dredge; set => SetProperty(ref dredge, value); }

        private string tugVesselName;
        [PropertyOrder(2)]
        public string TugVesselName { get => tugVesselName; set => SetProperty(ref tugVesselName, value); }

        private DisposalArea disposalArea = CharlestonDeepening2Service.GetDisposalAreas().First();
        [PropertyOrder(3)]
        [ItemsSource(typeof(DisposalAreaItemsSource))]
        public DisposalArea DisposalArea { get => disposalArea; set => SetProperty(ref disposalArea, value); }

        private bool isEmergencyDump;
        [PropertyOrder(4)]
        public bool IsEmergencyDump { get => isEmergencyDump; set => SetProperty(ref isEmergencyDump, value); }

        public UserInput ToUserInput()
        {
            return new UserInput(
                dredgeLoadNumber: DredgeLoadNumber,
                dredge: Dredge,
                tugVesselName: TugVesselName,
                disposalArea: DisposalArea,
                isEmergencyDump: IsEmergencyDump);
        }
    }
    public class DredgeItemsSource : IItemsSource
    {
        private readonly ItemCollection dredges;

        public DredgeItemsSource()
        {
            dredges = new ItemCollection();
            dredges.AddRange(Enumeration.GetAll<Dredge>().Select(d => new Item { Value = d, DisplayName = d.Name }));
        }

        public ItemCollection GetValues() => dredges;
    }

    public class DisposalAreaItemsSource : IItemsSource
    {
        private readonly ItemCollection _disposalAreas;

        public DisposalAreaItemsSource()
        {
            _disposalAreas = new ItemCollection();
            _disposalAreas.AddRange(
                CharlestonDeepening2Service.GetDisposalAreas()
                .Select(d => new Item { Value = d, DisplayName = d.Name }));
        }

        public ItemCollection GetValues() => _disposalAreas;
    }
}