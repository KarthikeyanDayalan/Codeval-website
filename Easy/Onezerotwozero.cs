using System;
using System.IO;

namespace Easy
{
    class Onezerotwozero
    {
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    string[] inp = line.Split(' ');
                    int numberOfZeroes = Convert.ToInt32(inp[0]);
                    int range = Convert.ToInt32(inp[1]);
                    //Console.WriteLine(Convert.ToString(range,2));
                    Console.WriteLine(FindZeroes(numberOfZeroes,range));
                }
        }

        public static int FindZeroes(int a, int b)
        {
            int output = 0;
            for (int i = 1; i <= b; i++ )
            {
                int balance, number = i,zeroCount = 0;
                string binary = string.Empty;
                while(number > 0)
                {
                    balance = number % 2;
                    number /= 2;
                    if(balance == 0)
                    {
                        zeroCount++;
                    }
                    binary = balance + binary;
                }
                if(zeroCount == a)
                {
                    output++;
                }
            }
            return output;
        }

    }
}
