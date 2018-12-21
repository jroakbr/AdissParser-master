namespace Gldd.AdissParser
{
    public interface IOutputDataCsvFileWriter
    {
        void Write(string filePath, OutputData outputData);
    }
}