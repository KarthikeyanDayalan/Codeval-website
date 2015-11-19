using System;
using System.IO;

namespace Withoutrepetitions
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
                    line = line + " ";
                    string output = string.Empty;
                    int i,j = 0;
                    for(i = 1 ; i < line.Length; i++)
                    {
                        if(line[i] != line[j])
                        {
                            output = output + line[j].ToString();
                            j = i;
                        }
                    }
                    //if (line[i-1] != line[i - 2])
                    //    output = output + line[i - 1];
                    Console.WriteLine(output);
                }
        }
    }
}
