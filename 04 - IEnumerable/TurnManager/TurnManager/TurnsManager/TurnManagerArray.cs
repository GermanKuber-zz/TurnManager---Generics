// using System;
// using System.Collections;
// using System.Collections.Generic;

// namespace TurnManager
// {
//     public class TurnManagerArray<T> : ITurnManager<T>
//     {
//         private T[] _turnsList;
//         private int _last = 0;
//         public int Capacity { get; }

//         int ITurnManager<T>.Capacity => throw new NotImplementedException();

//         private int _totalCount;
//         public TurnManagerArray() : this(capacity: 10)
//         {
//         }
//         public TurnManagerArray(int capacity)
//         {
//             _turnsList = new T[capacity + 1];
//             Capacity = capacity;
//         }
//         public bool Add(T number)
//         {
//             if (_last < Capacity)
//             {
//                 _turnsList[_last] = number;
//                 ++_totalCount;
//                 ++_last;
//                 return true;
//             }
//             return false;
//         }
//         public T Get()
//         {
//             var returnData = _turnsList[0];
//             for (int i = 1; i < Capacity; i++)
//             {
//                 _turnsList[i - 1] = _turnsList[i];
//             }
//             --_last;
//             return returnData;
//         }
//         public bool IsEmpty() => _last == 0;
//         //TODO: 02 - Implemento la interace IEnumerator
//         IEnumerator<T> IEnumerable<T>.GetEnumerator()
//         {
//             foreach (var item in _turnsList)
//                 yield return item;
//         }

//         bool ITurnManager<T>.Add(T number)
//         {
//             throw new NotImplementedException();
//         }

//         T ITurnManager<T>.Get()
//         {
//             throw new NotImplementedException();
//         }

//         bool ITurnManager<T>.IsEmpty()
//         {
//             throw new NotImplementedException();
//         }

//         IEnumerator IEnumerable.GetEnumerator()
//         {
//             throw new NotImplementedException();
//         }
//     }

// }