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
            //TestLinkedList(new SingleLinkedList<string>());
            TestLinkedList(new DoubleList<string>());

            Console.WriteLine();

            //TestLinkedList(new DoubleList<string>());

            Console.ReadKey();
        }

        private static void TestLinkedList(ILinkedList<string> list)
        {
            list.AddToBegin("End");
            list.AddToBegin("asf");
            list.AddToBegin("grfg");
            list.AddToBegin("Epppp");
            list.AddToBegin("dghj");
            list.AddToBegin("tyutyi");

            foreach (string item in list)
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("REMOVE FIRST ELEMENT");

            list.RemoveFromBegin();
            //list.RemoveFromEnd();

            foreach (string item in list)
            {
                Console.Write($"{item}\t");
            }

            Console.WriteLine();
            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("AFTER REVERSE: ");

            foreach (string item in list.GetReverse())
            {
                Console.Write($"{item}\t");
            }
            Console.WriteLine();
        }
    }
}
