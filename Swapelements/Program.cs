using System.IO;
using System;

namespace Swapelements
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
                    var temp = line.Trim().Split(':');
                    var input = temp[0].Trim().Split(' ');
                    var swap = temp[1].Trim().Split(',');
                    foreach (var item in swap)
                    {
                        var element = item.Split('-');
                        var value = input[Convert.ToInt32(element[0])];
                        input[Convert.ToInt32(element[0])] = input[Convert.ToInt32(element[1])];
                        input[Convert.ToInt32(element[1])] = value;
                    }
                    foreach (var item in input)
                    {
                        Console.Write(item + " ");
                    }
                    Console.WriteLine();
                }
        }
    }
}
