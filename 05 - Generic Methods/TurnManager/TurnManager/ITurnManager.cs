using System.Collections.Generic;

namespace TurnManager
{
    public interface ITurnManager<T> : IEnumerable<T>
    {
        bool Add(T number);
        T Get();
        int Capacity { get; }
        bool IsEmpty();
        //TODO: 01 - Agrego un metodo para convertir el tipo de mi lista
        IEnumerable<TOutPut> ToEnumerable<TOutPut>();
    }

}