using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList
{
    interface ILinkedList<T> : IEnumerable<T>
    {
        bool IsEmpty();

        void AddToBegin(T item);

        void AddToEnd(T item);

        void Sort();

        T RemoveFromBegin();

        T RemoveFromEnd();

        IEnumerable<T> GetReverse();
    }
}
