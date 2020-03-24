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

        T RemoveFromBegin();

        T RemoveFromEnd();

        void GetSortList();

        IEnumerable<T> GetReverse();
    }
}
