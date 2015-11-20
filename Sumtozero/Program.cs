using System;
using System.Collections.Generic;
using System.IO;

namespace Sumtozero
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
                    var input = line.Split(',');
                    int[] array = new int[input.Length];
                    int z = 0, count = 0;
                    foreach (var item in input)
                    {
                        array[z] = Convert.ToInt32(item);
                        z++; 
                    }

                    for (int i = 0; i < array.Length; i++)
                    {
                        for (int j = i+1; j < array.Length; j++)
                        {
                            for (int k = j+1; k < array.Length; k++)
                            {
                                for (int l = k+1; l < array.Length; l++)
                                {
                                    if(array[i] + array[j] + array[k] + array[l] == 0)
                                    {
                                        count++;
                                    }
                                }
                            }
                        }
                    }
                    Console.WriteLine(count);
                }
        }
    }
}
