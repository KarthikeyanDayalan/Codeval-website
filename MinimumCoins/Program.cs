using System.IO;
using System;

namespace MinimumCoins
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
                    int count = 0, value = Convert.ToInt32(line);
                    while(value > 0)
                    {
                        if (value >= 5)
                        {
                            value -= 5;
                            count++;
                        }
                        else if (value >= 3 && value < 5)
                        {
                            value -= 3;
                            count++;
                        }
                        else if (value >= 1 && value < 3)
                        {
                            value -= 1;
                            count++;
                        }
                    }
                    Console.WriteLine(count);
                }
        }
    }
}
