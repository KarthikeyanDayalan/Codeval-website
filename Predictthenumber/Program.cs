using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Predictthenumber
{
    class Program
    {
        static void Main(string[] args)
        {
            char[] sequence = new char[3000000000];
            sequence[0] = '0';
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    
                    var dest = Convert.ToInt64(line);
                    while (dest > sequence.Length)
                    {
                        var len = sequence.Length;
                        for (int i = 0; i < len; i++)
                        {
                            if (sequence[i] == '0')
                            {
                                sequence[len + i] = '1';
                            }
                            else if (sequence[i] == '1')
                            {
                                sequence[len + i] = '2';
                            }
                            else if (sequence[i] == '2')
                            {
                                sequence[len + i] = '0';
                            }
                        }
                    }

                    Console.WriteLine(sequence[dest]);
                }
        }
    }
}