using System.IO;

namespace Gldd.AdissParser
{
    public interface IAdissCsvFileParser
    {
        AdissCsvFile Parse(string filePath);
    }
}