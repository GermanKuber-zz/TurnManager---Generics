using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
namespace TurnManager
{
    public class TurnManagerQueue<T> : ITurnManager<T>
    {
        private Queue<T> _turnsList;
        private int _actualCount = 0;
        public int Capacity { get; }
        private int _totalCount;
        public TurnManagerQueue() : this(capacity: 10)
        {
        }
        public TurnManagerQueue(int capacity)
        {
            _turnsList = new Queue<T>();
            Capacity = capacity;
        }
        public bool Add(T value)
        {
            if (_actualCount < Capacity)
            {
                _turnsList.Enqueue(value);
                ++_totalCount;
                ++_actualCount;
                return true;
            }
            return false;
        }
        public T Get()
        {
            --_actualCount;
            return _turnsList.Dequeue();
        }
        public bool IsEmpty() => _actualCount == 0;

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
        public IEnumerable<TOutPut> ToEnumerable<TOutPut>(Func<T, TOutPut> funcConvert)
        {
            foreach (var item in _turnsList)
                yield return funcConvert.Invoke(item);

        }
    }

}