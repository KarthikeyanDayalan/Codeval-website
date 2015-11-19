using System;
using System.Collections.Generic;
using System.IO;

namespace Sudoku
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
                    string[] input = line.Split(';');
                    int rc = Convert.ToInt32(input[0]);
                    string[] values = input[1].Split(',');
                    int[,] table = new int[rc, rc];
                    int[] test = new int[rc];
                    int k = 0,flag = 0;
                    for(int i = 0; i < rc; i++)
                    {
                        Array.Clear(test, 0, rc);
                        for(int j = 0; j < rc; j++)
                        {
                            int temp = Convert.ToInt32(values[k]);
                            table[i,j] = temp;
                            test[temp-1]++;
                            k++;
                        }
                        for(int l = 0; l < rc; l++)
                        {
                            if(test[l] != 1)
                            {
                                flag = 1;
                                Console.WriteLine("False");
                                break;
                            }
                        }
                        if (flag == 1)
                            break;
                    }
                    if(flag ==0)
                    {
                        Console.WriteLine("True");
                    }
                }
        }
    }
}
