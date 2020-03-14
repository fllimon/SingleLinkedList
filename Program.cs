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

            foreach (string item in list)
            {
                Console.Write($"\t{item}");
            }
            Console.WriteLine();

            list.AddToBegin("ttyfdf");
            list.AddToBegin("w.z");

            foreach (string item in list)
            {
                Console.Write($"\t{item}");
            }
            Console.WriteLine();

            list.AddToBegin("Start");
            list.AddToEnd("End");

            foreach (string item in list)
            {
                Console.Write($"\t{item}");
            }

            Console.WriteLine();

            Console.ReadKey();
        }
    }
}
