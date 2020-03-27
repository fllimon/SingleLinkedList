using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList.Exception
{
    class GetNonexistentElementExeption : System.Exception
    {
        #region ======----- CTOR ------======

        public GetNonexistentElementExeption()
        {

        }

        public GetNonexistentElementExeption(string message)
        {

        }

        public GetNonexistentElementExeption(string message, System.Exception innerExeption)
        {

        }

        #endregion
    }
}
