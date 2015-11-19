using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RemoveCharacters
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
                    StringBuilder sb = new StringBuilder();
                    int flag = 0;
                    string[] input = line.Trim().Split(',');
                    for (int i = 0; i < input[0].Length; i++)
                    {
                        flag = 0;
                        if (input[0][i] != ' ')
                        {
                            for (int j = 0; j < input[1].Length; j++)
                            {
                                if (input[0][i] == input[1][j])
                                {
                                    flag = 1;
                                }
                            }
                        }
                        if(flag == 0)
                            sb.Append(input[0][i]);
                    }
                    Console.WriteLine(sb);
                }
        }
    }
}
