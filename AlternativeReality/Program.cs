using System;
using System.IO;

namespace AlternativeReality
{
    class Program
    {
        static int count;
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    count = 0;
                    int input = Convert.ToInt32(line);
                    int[] denoms = new int[] { 1, 5, 10, 25, 50 };
                    findAllCombinationsRecursive(0, input, denoms);
                    Console.WriteLine(count);
                }
        }

        public static void findAllCombinationsRecursive(int startIx, int remainingTarget, int[] denoms)
        {
            for (int i = startIx; i < denoms.Length; i++)
            {
                int temp = remainingTarget - denoms[i];
                if (temp < 0)
                {
                    break;
                }
                if (temp == 0)
                {
                    count++;
                    break;
                }
                else
                {
                    findAllCombinationsRecursive(i, temp, denoms);
                }
            }
        }
    }
}
