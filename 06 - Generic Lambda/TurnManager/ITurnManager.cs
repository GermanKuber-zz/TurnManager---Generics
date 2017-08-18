using System;
using System.Collections.Generic;

namespace TurnManager
{
    public interface ITurnManager<T> : IEnumerable<T>
    {
        bool Add(T number);
        T Get();
        int Capacity { get; }
        bool IsEmpty();
        //TODO: 01 - Implemento una funciona con generic de parametros
        IEnumerable<TOutPut> ToEnumerable<TOutPut>(Func<T, TOutPut> funcConvert);
    }

}