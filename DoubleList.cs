using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList
{
    class DoubleList<T> : ILinkedList<T>, IEnumerable<T>
        //where T : IComparable<T>
    {
        #region =====---- PRIVATE DATA ----======

        private Node _first = null;
        private Node _last = null;

        #endregion

        public bool IsEmpty()
        {
            return (_first == null);
        }

        public T AddToBegin(T item)
        {
            Node newNode = new Node(item);

            newNode.Next = _first;

            if (IsEmpty())
            {
                _last = newNode;
            }
            else
            {
                _first.Previus = newNode;
            }

            _first = newNode;

            return newNode.Info;
        }

        public T AddToEnd(T item)
        {
            Node newNode = new Node(item);

            if (IsEmpty())
            {
                _last = newNode;
            }
            else
            {
                _last.Previus = newNode;
            }

            _last = newNode;

            return newNode.Info;
        }

        public T RemoveFromBegin()
        {
            if (!IsEmpty())
            {
                Node current = _first;
                current = current.Next;
                _first = current;
            }

            return _first.Info;
        }

        public T RemoveFromEnd()
        {
            if (_last != null)
            {
                Node current = _last;
                current = current.Previus;
                _last = current;
            }

            return _last.Info;
        }

        public IEnumerable<T> GetReverse(bool isReverse)
        {
            Node current = _last;

            if (isReverse)
            {
                if (current != null)
                {
                    current = current.Previus;
                }
            }

            return (IEnumerable<T>)current;    // ToDo: !! ВОПРОС? !!
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new DoubleListContainer(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DoubleListContainer(this);
        }

        #region =====----- CONTAINER IENUMERATOR -----=====

        private struct DoubleListContainer : IEnumerator<T>
        {
            #region ====---- PRIVATE DATA ----====

            private readonly DoubleList<T> _doubleList;
            private Node _current;
            private int _position;
            
            #endregion

            #region =====----- CTOR -----=====

            public DoubleListContainer(DoubleList<T> doubleList)
            {
                _doubleList = doubleList;
                _current = _doubleList._first;
                _position = -1;
            }

            #endregion

            T IEnumerator<T>.Current
            {
                get
                {
                    return _current.Info;
                }
            }

            object IEnumerator.Current
            {
                get
                {
                    return _current.Info;
                }
            }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_position++ != -1)
                {
                    _current = _current.Next;
                }

                return _current != null;
            }

            void IEnumerator.Reset()
            {
                _current = _doubleList._first;
            }
        }

        #endregion

        private class Node
        {
            public Node(T item)
            {
                Info = item;
            }

            public T Info { get; set; }

            public Node Next { get; set; } = null;

            public Node Previus { get; set; } = null;
        }
    }
}
