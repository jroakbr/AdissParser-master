namespace Gldd.AdissParser
{
    public interface ICharlestonDeepening2Service
    {
        bool IsWithinBermArea(Point2D point2D);
        bool IsWithinChannel(Point2D point2D);
        bool ShouldDumpInBermArea(DisposalArea disposalArea);
    }
}