using System;
using System.IO;

namespace Guessthewine
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
                    string[] input = line.Trim().Split('|');
                    string[] wines = input[0].Trim().Split(' ');
                    string check = input[1].Trim();
                    int flag = 0;
                    foreach(string item in wines)
                    {
                        
                        int[] tick = new int[check.Length];
                        int count = 0;
                        for (int i = 0; i < item.Length; i++)
                        {
                            for(int j = 0 ; j < check.Length; j++)
                            {
                                if(item[i] == check[j] && tick[j] == 0)
                                {
                                    tick[j] = 1;
                                    count++;
                                    break;
                                }
                            }
                        }
                        if(count == check.Length)
                        {
                            Console.Write(item+' ');
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                        Console.WriteLine("False");
                    else
                        Console.WriteLine();
                }
        }
    }
}