using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList
{
    class RemoveNonexistentElementExeption : System.Exception
    {
        #region ======----- CTOR ------======

        public RemoveNonexistentElementExeption()
        {

        }

        public RemoveNonexistentElementExeption(string message)
        {

        }

        public RemoveNonexistentElementExeption(string message, System.Exception innerExeption)
        {

        }

        #endregion
    }
}
