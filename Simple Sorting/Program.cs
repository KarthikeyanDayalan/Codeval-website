using System;
using System.IO;

namespace Simple_Sorting
{
    class Program
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    var input = line.Split(' ');
                    int i = 0;
                    double[] input_array = new double[input.Length];
                    foreach (var item in input)
                    {
                        input_array[i] = Convert.ToDouble(item);
                        i++;
                    }
                    Array.Sort(input_array);
                    foreach (var item in input_array)
                    {
                        Console.Write("{0:0.000}",item);
                        Console.Write(" ");
                    }
                    Console.WriteLine();
                }
        }
    }
}
