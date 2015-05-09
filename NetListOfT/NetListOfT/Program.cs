using System;

namespace NetListOfT
{
    class Program
    {
        static void Main(string[] args)
        {
            MyList<int> List1 = new MyList<int>();
            MyList<int> List2 = new MyList<int>();

            List1.Add(15);
            List1.Add(16);
            List1.Add(17);
            List1.Add(18);

            Console.WriteLine(List1.Count);

            Console.WriteLine(List1[2]);

            List1.RemoveAt(1);

            Console.WriteLine(List1.Contains(16));

            Func<int, bool> checkMethod = CheckEven;
            List2 = List1.FindAll(checkMethod);
            Console.WriteLine(List2.Count);

            List1.Clear();

            Console.WriteLine(List1.Count);
        }

        private static bool CheckEven(int number)
        {
            if (number % 2 == 0) return true;
            return false;
        }

    }
}

