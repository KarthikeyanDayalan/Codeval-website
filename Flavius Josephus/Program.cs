using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Flavius_Josephus
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
                    string[] input = line.Split(',');
                    int circle_length = Convert.ToInt32(input[0]);
                    int kill = Convert.ToInt32(input[1]);
                    bool[] trial = new bool[circle_length];
                    int i = 0, j=0, count = 0;
                    while(count < circle_length)
                    {
                        if (j >= circle_length)
                        {
                            j = 0;
                        }
                        if (i == (kill-1) && trial[j] == false)
                        {
                            trial[j] = true;
                            i = 0;
                            count++;
                            Console.Write(j+" ");
                        }
                        if (trial[j] == false)
                        {
                            i++;
                        }
                        j++;
                        
                    }
                    Console.WriteLine();
                }
            
        }
    }
}
