using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList
{
    interface IStack<T>
    {
        bool IsEmpty();

        void Push(T item);

        T Pop();
    }
}
