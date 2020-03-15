using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList
{
    class SingleLinkedList<T> : IEnumerable<T>
    {
        private Node _first = null;
        private Node _last = null;
               
        public bool IsEmpty()
        {
            return (_first == null);
        }

        public void AddToEnd(T item)
        {
            Node node = new Node(item);

            if (IsEmpty())
            {
                _first = node;
            }
            else
            {
                Node current = _first;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                node.Info = item;
                current.Next = node;
            }            
        }

        public void AddToBegin(T item)
        {
            Node node = new Node(item);

            node.Info = item;
            node.Next = _first;
            _first = node;
        }

        public void RemoveItem(T item)
        {
            Node node = new Node(item);
            Node current = _first;
            Node someElement = null;

            node.Info = item;

            while (current != null)
            {
                if (current.Info.Equals(item))
                {
                    if (someElement != null)
                    {
                        someElement.Next = current.Next;

                        if (current.Next == null)
                        {
                            _last = someElement;
                        }
                    }
                    else
                    {
                        _first = _first.Next;

                        if (_first == null)
                        {
                            _last = null;
                        }
                    }

                    break;
                }
                someElement = current;
                current = current.Next;
            }
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            Node current = _first;

            while (current != null)
            {
                yield return current.Info;
                current = current.Next;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return ((IEnumerable)this).GetEnumerator();
        }

        private class Node
        {
            #region ======------ PRIVATE DATA -----=====

            private T _item;
            
            #endregion

            #region ======----- CTOR -----======

            public Node(T item)
            {
                _item = item;
            }

            #endregion

            #region =====---- PROPERTIES -----=====

            public T Info { get; set; }

            public Node Next { get; set; }

            #endregion
        }
    }
}
