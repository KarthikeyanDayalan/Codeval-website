using System;
using System.IO;

namespace Pangrams
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
                    line = line.ToLower();
                    int flag = 0;
                    char[] alphabets = new char[26];
                    for (int i = 0; i < line.Length; i++)
                    {
                        if(line[i] >= 97 && line[i] <= 122)
                        {
                            alphabets[line[i] - 97]++;
                        }
                    }
                    for (int i = 0; i < alphabets.Length; i++)
                    {
                        if(alphabets[i] == 0)
                        {
                            Console.Write(Convert.ToChar(i+97));
                            flag = 1;
                        }
                    }
                    if(flag == 0)
                    {
                        Console.Write("NULL");
                    }
                    Console.WriteLine();
                }
        }
    }
}
