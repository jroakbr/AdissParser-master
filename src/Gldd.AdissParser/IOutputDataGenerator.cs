using System.Collections.Generic;

namespace Gldd.AdissParser
{
    public interface IOutputDataGenerator
    {
        OutputData Generate(UserInput userInput, DredgeRecord dredgeRecord, AdissCsvFile adissCsvFile);
    }
}