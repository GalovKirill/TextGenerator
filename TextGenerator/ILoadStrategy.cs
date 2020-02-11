using System.Collections.Generic;

namespace TextGenerator
{
    public interface ILoadStrategy
    {
        void Load();

        ICharGenerator GetResult();
    }
}