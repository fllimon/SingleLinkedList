using System;
using System.Collections;
using System.Collections.Generic;

using MySimpleLinkedList.Exception;

namespace MySimpleLinkedList
{
    class DoubleList<T> : ILinkedList<T>, IQueue<T>, IStack<T>
        where T : IComparable<T>
    {
        #region =====---- PRIVATE DATA ----======

        private Node _first = null;
        private Node _last = null;

        #endregion

        #region =======------ METHOD'S -------=======

        public bool IsEmpty()
        {
            return (_first == null);
        }

        public void AddToBegin(T item)
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
        }

        public void AddToEnd(T item)
        {
            Node newNode = new Node(item);

            if (IsEmpty())
            {
                _first = newNode;
                _last = newNode;
            }
            else
            {
                newNode.Previus = _last;
                _last.Next = newNode;
            }

            _last = newNode;
        }

        private bool Swap(Node currentItem)
        {
            if (currentItem.Next == null)
            {
                return false;
            }

            bool result = false;

            if (currentItem.Info.CompareTo(currentItem.Next.Info) > 0)
            {
                bool isCurrenFirst = (currentItem == _first);
                bool isCurrenNextLast = (currentItem.Next == _last);

                // currentItem   <--->   currentItem.Next

                if (!isCurrenFirst)
                {
                    currentItem.Previus.Next = currentItem.Next;    // (1)
                }
                
                currentItem.Next.Previus = currentItem.Previus;    //(2)

                Node temp = currentItem.Next;    // ссылка на следующий узел  (3)

                currentItem.Next = temp.Next;    // (4)
                temp.Next = currentItem;    // (5)

                if (!isCurrenNextLast)
                {
                    currentItem.Next.Previus = currentItem;    // (6)
                }

                if (isCurrenFirst)
                {
                    _first = temp;
                }

                if (isCurrenNextLast)
                {
                    _last = currentItem;
                }

                result = true;
            }

            //Node tmp = currentItem;
            //firstItem = secondItem;
            //secondItem = tmp;


            return result;
        }

        public void Sort()
        {
            if (IsEmpty())
            {
                //throw new GetNonexistentElementExeption();  
                return;
            }            

            bool swaped = false;

            do
            {
                Node current = _first;

                swaped = false;

                while (current.Next != null)
                {                    
                    if (Swap(current))
                    {
                        swaped = true;
                    }
                    current = current.Next;
                }
                foreach (var item in this)
                {
                    Console.Write($"{item} ");
                }

                Console.WriteLine();
            }
            while (swaped);

        }

        public T GetFirst()
        {
            if (IsEmpty())
            {
                throw new GetNonexistentElementExeption();
            }

            T result = _first.Info;

            return result;
        }

        public T RemoveFromBegin()
        {
            if (IsEmpty())
            {
                throw new RemoveNonexistentElementExeption();
            }

            T result = _first.Info;
            _first = _first.Next;

            if (_first == null)
            {
                _last = null;
            }

            return result;
        }

        public T RemoveFromEnd()
        {
            if (IsEmpty())
            {
                throw new RemoveNonexistentElementExeption();
            }            

            T result = _last.Info;
            _last = _last.Previus;

            if (_last == null)
            {
                _first = null;
            }

            return result;
        }

        #endregion  

        #region ======----- IENUMERABLE/IENUMERATOR METHOD ------======

        public IEnumerable<T> GetReverse()
        {
            ReverseIterator container = new ReverseIterator(this);

            return container;
        }

        IEnumerator<T> IEnumerable<T>.GetEnumerator()
        {
            return new DoubleListContainer(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return new DoubleListContainer(this);
        }

        #region ====---- IQueue -----=====

        void IQueue<T>.Put(T item)
        {
            AddToEnd(item);
        }

        T IQueue<T>.Get()
        {
            return GetFirst();
        }

        #endregion

        #region ======----- IStack ------======

        void IStack<T>.Push(T item)
        {
            AddToBegin(item);
        }

        T IStack<T>.Pop()
        {
            return GetFirst();
        }

        public void GetSortList()
        {
            throw new NotImplementedException();
        }

        #endregion

        #endregion

        #region =====----- CONTAINER IENUMERATOR -----=====

        private struct DoubleListContainer : IEnumerator<T>
        {
            #region ====---- PRIVATE DATA ----====

            private readonly DoubleList<T> _doubleList;
            private Node _current;
            private bool _isPosition;
            
            #endregion

            #region =====----- CTOR -----=====

            public DoubleListContainer(DoubleList<T> doubleList)
            {
                _doubleList = doubleList;
                _current = _doubleList._first;
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

            public void Dispose()
            {
            }

            public bool MoveNext()
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
                _current = _doubleList._first;
            }
        }

        #endregion

        #region ======------ REVERSE CONTAINER -----======
        private struct ReverseIterator : IEnumerable<T>, IEnumerator<T>
        {
            private readonly DoubleList<T> _doubleList;
            private Node _current;
            private bool _isPosition;
            
            public ReverseIterator(DoubleList<T> doubleList)
            {
                _doubleList = doubleList;
                _current = doubleList._last;
                _isPosition = false;
            }

            public T Current
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
                if (_isPosition)
                {
                    _current = _current.Previus;
                }
                _isPosition = true;

                return _current != null;
            }

            public void Reset()
            {
                _current = _doubleList._last;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return this;    
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return this;
            }
        }

        #endregion

        #region ======----- LIST NODE ------======

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

        #endregion
    }
}
