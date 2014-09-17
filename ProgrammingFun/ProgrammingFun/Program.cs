using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingFun
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length < 1)
            {
                Console.WriteLine("Usage ProgrammingFun <Problem> <Problem Args>");
                Environment.Exit(-1);
            }

            switch (args[0])
            {
                case "SpiralArray":
                    if (args.Length != 2)
                    {
                        Console.WriteLine("Usage ProgrammingFun SpiralArray <2d array>");
                        Environment.Exit(-1);
                    }
                    var arr = ArrayParseInt2d(args[1]);
                    printArray2d(arr);
                    printSpiralArray(arr);
                    break;
                case "MaxiumContiguousSubsequence":
                    if (args.Length != 2)
                    {
                        Console.WriteLine("Usage ProgrammingFun MaximumContiguousSubseqence <1d array>");
                        Environment.Exit(-1);
                    }
                    var arr2 = ArrayParseInt1d(args[1]);
                    printArray(arr2);
                    printMaximumContiguousSubsequence(arr2);
                    break;
                default:
                    Console.WriteLine("Unknown Command");
                    break;
            }

            Console.ReadLine();
        }

        static void printMaximumContiguousSubsequence(List<int> arr)
        {
            var max = arr[0];
            var max_start = 0;
            var max_end = 0;
            var S = arr[0];
            var T = 0;
            for (var i = 1; i < arr.Count; i++)
            {
                if (S > 0)
                {
                    S = S + arr[i];
                }
                else
                {
                    S = arr[i];
                    T = i;
                }
                if (S > max)
                {
                    max_start = T;
                    max_end = i;
                    max = S;
                }
            }
            Console.WriteLine(String.Format("Max Sum: {0} Start {1} End {2}", max, max_start, max_end));
        }

        static void printArray(List<int> arr)
        {
            foreach (var o in arr)
            {
                Console.Write(o.ToString() + (o == arr.Last() ? "" : ","));
            }
            Console.WriteLine();
        }

        static void printArray2d(List<List<int>> arr2)
        {
            foreach (var arr in arr2) {
                foreach (var o in arr)
                {
                    Console.Write(o.ToString() + (o == arr.Last() ? "" : ","));
                }
                Console.WriteLine();
            }
        }

        static void printSpiralArray(List<List<int>> arr2)
        {
            var offset = 0;
            while (offset < Math.Ceiling((double)Math.Min(arr2.Count, arr2[0].Count) / 2))
            {
                int x = offset;
                int y = offset;
                for (; x < arr2[0].Count - offset; x++)
                {
                    Console.Write(arr2[y][x]);
                }
                x--;
                for (y=y+1; y < arr2.Count - offset; y++)
                {
                    Console.Write(arr2[y][x]);
                }
                y--;
                for (x=x-1; x >= offset; x--)
                {
                    Console.Write(arr2[y][x]);
                }
                x++;
                for (y=y-1; y > offset; y--)
                {
                    Console.Write(arr2[y][x]);
                }
                offset++;
            }
        }

        static List<List<int>> ArrayParseInt2d(string arg)
        {
            var ret = new List<List<int>>();
            arg = arg.Substring(1, arg.Length -1);
            foreach (var e in arg)
            {
                if (e == '[')
                {
                    ret.Add(new List<int>());
                }
                else if (e != ']' && e != ',')
                {
                    ret.Last().Add(e - '0');
                }
            }
            return ret;
        }

        static List<int> ArrayParseInt1d(string arg)
        {
            var ret = new List<int>();
            arg = arg.Trim();
            arg = arg.Substring(1);
            arg = arg.Substring(0, arg.Length-1);
            var l = arg.Split(',');
            foreach (var e in l) {
                ret.Add(Int32.Parse(e));
            }
            return ret;
        }
    }
}
