using System;
using System.IO;
using System.Collections.Generic;

namespace Timetoeat
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
                    string[] Timestamps = line.Trim().Split(' ');
                    Dictionary<int, string> output = new Dictionary<int, string>();
                    List<int> timediff = new List<int>();
                    foreach(string item in Timestamps)
                    {
                        string[] hhmmss = item.Split(':');
                        int time = Convert.ToInt32(hhmmss[0]) * 3600 + Convert.ToInt32(hhmmss[1]) * 60 + Convert.ToInt32(hhmmss[2]);
                        output.Add(time,item);
                        timediff.Add(time);
                    }
                    timediff.Sort();
                    timediff.Reverse();
                    foreach(var item in timediff)
                    {
                        Console.Write(output[item]+' ');
                    }
                    Console.WriteLine();
                }
        }
    }
}
