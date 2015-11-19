using System;
using System.Collections.Generic;
using System.IO;

namespace Trailingstrings
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
                    int i, j = input[0].Length - 1;
                    for (i = input[1].Length - 1; i > 0; i-- )
                    {
                        if(input[1][i] != input[0][j])
                        {
                            Console.WriteLine("0");
                            break;
                        }

                        j--;
                    }
                    if(i < 0 && input[0][j] == ' ' )
                    {
                        Console.WriteLine("1");
                    }
                    else if(i < 0 && input[0][j] != ' ')
                    {
                        Console.WriteLine("0");
                    }
                }
        }
    }
}