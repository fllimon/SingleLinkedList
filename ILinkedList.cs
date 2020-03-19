using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList
{
    interface ILinkedList<T> : IEnumerable<T>
    {
        //T GetFirst();

        bool IsEmpty();

        T AddToBegin(T item);

        T AddToEnd(T item);

        T RemoveFromBegin();

        T RemoveFromEnd();

        IEnumerable<T> GetReverse(bool isReverse);
    }
}
