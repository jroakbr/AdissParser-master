namespace Gldd.AdissParser
{
    public class UserInput
    {
        public UserInput(int dredgeLoadNumber, Dredge dredge, string tugVesselName, DisposalArea disposalArea, bool isEmergencyDump)
        {
            DredgeLoadNumber = dredgeLoadNumber;
            Dredge = dredge;
            TugVesselName = tugVesselName;
            DisposalArea = disposalArea;
            IsEmergencyDump = isEmergencyDump;
        }

        public int DredgeLoadNumber { get; }
        
        public Dredge Dredge { get; }

        public string TugVesselName { get; }

        public DisposalArea DisposalArea { get; }

        public bool IsEmergencyDump { get; }
    }
}