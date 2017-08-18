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
            var item = _turnsList.Dequeue();
            //TODO: 04 - Ejecuto el evento
            RaiseEvent(item);
            return item;
        }
        public bool IsEmpty() => _actualCount == 0;

        //TODO: 03 - Lanzo el evento
        private void RaiseEvent(T item)
        {
            var arg = new GetItemEventArgs<T>(item);
            this.GetItemEvent(this,arg);
        }
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
        //TODO: 02 - Genero un evento en mi clase
        public event EventHandler<GetItemEventArgs<T>> GetItemEvent;
    }

    //TODO: 01 - Creo un EventArts custom
    public class GetItemEventArgs<T> : EventArgs
    {
        public GetItemEventArgs(T item)
        {
            this.Item = item;
        }
        public T Item { get; set; }
    }

}