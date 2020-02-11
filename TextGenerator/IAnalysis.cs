using System.Collections.Generic;

namespace TextGenerator
{
    interface IAnalysis
    {
        void Print(IDictionary<SubString, List<char>> chars);
    }
}