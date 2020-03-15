using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MySimpleLinkedList
{
    class Program
    {
        static void Main(string[] args)
        {
            SingleLinkedList<string> list = new SingleLinkedList<string>();

            list.AddToBegin("ghkvbh");
            list.AddToEnd("PreEnd");
            list.AddToBegin("Start");
            list.AddToEnd("End");

            foreach (string item in list)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();

            list.RemoveItem("ghkvbh");

            foreach (string item in list)
            {
                Console.Write($"{item}\t");
            }


            Console.ReadKey();
        }
    }
}
