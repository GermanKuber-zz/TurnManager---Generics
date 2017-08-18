using System;
using System.Collections;
using System.Collections.Generic;

namespace TurnManager
{
    public class TurnManagerArray<T> : ITurnManager<T>
    {
        private T[] _turnsList;
        private int _last = 0;
        public int Capacity { get; }

        int ITurnManager<T>.Capacity => throw new NotImplementedException();

        private int _totalCount;
        public TurnManagerArray() : this(capacity: 10)
        {
        }
        public TurnManagerArray(int capacity)
        {
            _turnsList = new T[capacity + 1];
            Capacity = capacity;
        }
        public bool Add(T number)
        {
            if (_last < Capacity)
            {
                _turnsList[_last] = number;
                ++_totalCount;
                ++_last;
                return true;
            }
            return false;
        }
        public T Get()
        {
            var returnData = _turnsList[0];
            for (int i = 1; i < Capacity; i++)
            {
                _turnsList[i - 1] = _turnsList[i];
            }
            --_last;
            return returnData;
        }
        public bool IsEmpty() => _last == 0;
        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            foreach (var item in _turnsList)
                yield return item;
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            foreach (var item in _turnsList)
                yield return item;
        }
        //TODO: 02 - Implemento una funciona con generic de parametros
        public IEnumerable<TOutPut> ToEnumerable<TOutPut>(Func<T, TOutPut> funcConvert)
        {
            foreach (var item in _turnsList)
                yield return funcConvert.Invoke(item);
        }

    }

}