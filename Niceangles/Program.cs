using System;
using System.IO;

namespace Niceangles
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
                string[] Wholenumber = line.Split('.');

                string output = Wholenumber[0]+'.';
                double min =(Convert.ToInt64(Wholenumber[1]) * 60)/ Math.Pow(10.00,Wholenumber[1].Length);
                //Console.WriteLine(min);
                Wholenumber = Convert.ToString(min).Split('.');
                output = output + Wholenumber[0].PadLeft(2,'0') +'\'';
                
                if (Wholenumber.Length == 2)
                {
                    min = (Convert.ToInt64(Wholenumber[1]) * 60) / Math.Pow(10.00, Wholenumber[1].Length);
                    Wholenumber = Convert.ToString(min).Split('.');
                }
                else
                {
                    Wholenumber[0] = "00";
                }
                output = output + Wholenumber[0].PadLeft(2,'0') + '"';
                Console.WriteLine(output);
            }
        }
    }
}
