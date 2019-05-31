using MyIListImplementation.Models;
using System;
using System.Collections.Generic;

namespace MyListImplementation.App
{
    class StartUp
    {
        static void Main(string[] args)
        {
            MyList<int> list = new MyList<int>();

            list.Add(0);
            list.Add(1);
            list.Add(2);

            list.Insert(0, 1);
            Console.WriteLine(string.Join(" ", list));
            list.Insert(1, 2);
            Console.WriteLine(string.Join(" ", list));

            int[] secondList = new int[list.Count];

            list.CopyTo(secondList, 0);

            Console.WriteLine(string.Join(" ", secondList));

            list[0] = 5;
            Console.WriteLine(string.Join(" ", list));
            Console.WriteLine(list[0]);

            Console.WriteLine(list.IndexOf(5));

            list.Add(5);

            Console.WriteLine(string.Join(" ", list));

            Console.WriteLine(list.Count);

            list.RemoveAt(3);

            Console.WriteLine(string.Join(" ", list));

            Console.WriteLine(list.Count);

            Console.WriteLine(list.IndexOf(5));

            MyList<string> stringList = new MyList<string>();

            stringList.Add(null);
            stringList.Contains("sada");


        }
    }
}
