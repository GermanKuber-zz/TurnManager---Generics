using System;
namespace TurnManager
{
    public class TurnManager
    {
        private int[] _turnsList;
        private int _last = 0;
        public int Capacity { get; }
        private int _totalCount;
        public TurnManager() : this(capacity: 10)
        {
        }
        public TurnManager(int capacity)
        {
            _turnsList = new int[capacity + 1];
            Capacity = capacity;
        }
        public bool Add(int number)
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
        public int Get()
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
    }

}