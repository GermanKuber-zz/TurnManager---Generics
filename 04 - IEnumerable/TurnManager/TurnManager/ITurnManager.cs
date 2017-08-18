using System.Collections.Generic;

namespace TurnManager
{
    //TODO: 01 -  Implemento la interface IEnumerable
    public interface ITurnManager<T> : IEnumerable<T>
    {
        bool Add(T number);
        T Get();
        int Capacity { get; }
        bool IsEmpty();
    }

}