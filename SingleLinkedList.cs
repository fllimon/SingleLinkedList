using System;
using System.Collections;
using System.Collections.Generic;

namespace MySimpleLinkedList
{
    class SingleLinkedList<T> : ILinkedList<T>, IEnumerable<T>
    {
        #region =======------ PRIVATE DATA -------=====

        private Node _first = null;
        private Node _last = null;

        #endregion

        #region ========------ METHOD'S -------=======

        public bool IsEmpty()
        {
            return (_first == null);
        }

        public void AddToEnd(T item)
        {
            Node node = new Node(item);

            if (IsEmpty())
            {
                _last = node;
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

        public T GetFirst()
        {
            if (IsEmpty())
            {
                _last = null;
            }

            T result = _first.Info;
            _first = _first.Next;

            return result;
        }

        public void AddToBegin(T item)
        {
            Node node = new Node(item)
            {
                Info = item,
                Next = _first
            };

            if (IsEmpty())
            {
                _last = node;
            }

            _first = node;
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
            if (IsEmpty())
            {
                _last = null;
            }
            else
            {
                Node lastNode = _first;

                if (lastNode.Next == null)
                {
                    _last = null;
                }
                else
                {
                    while (lastNode.Next != null)
                    {
                        lastNode = lastNode.Next.Next;
                    }

                    lastNode.Next = null;
                }
            }

            return _last.Info;
        }

        public void GetSortList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ======------- IENUMERABLE/IENUMERATOR METHOD ------=======

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new ListConteiner(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new ListConteiner(this);
        }

        public IEnumerable<T> GetReverse()
        {
            throw new NotImplementedException();
        }

        public void Sort()
        {
            throw new NotImplementedException();
        }

        #endregion

        #region ======------ CONTEINER ENUMERATOR -----=====

        private struct ListConteiner : IEnumerator<T>
        {
            #region =====---- PRIVATE DATA ----====

            private readonly SingleLinkedList<T> _list;
            private Node _current;
            private bool _isPosition;

            #endregion

            #region =====----- CTOR -----====

            public ListConteiner(SingleLinkedList<T> list)
            {
                _current = list._first;
                _list = list;
                _isPosition = false;
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

            void IDisposable.Dispose()
            {    
            }

            bool IEnumerator.MoveNext()
            {
                if (_isPosition)
                {
                    _current = _current.Next;
                }
                _isPosition = true;

                return _current != null;
            }

            void IEnumerator.Reset()
            {
                _current = _list._first;
            }
        }

        #endregion

        #region ======----- LIST NODE ------=====

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

        #endregion
    }
}
