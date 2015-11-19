using System;
using System.IO;

namespace Stringsandarrows
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
                    string arrow1 = "<--<<";
                    string arrow2 = ">>-->";
                    int count = 0;
                    char[] newString = new char[5];

                    for (int i = 0; i < line.Length - 4; i++)
                    {
                        Array.Clear(newString,0,4);
                        newString[0] = line[i];
                        newString[1] = line[i+1];
                        newString[2] = line[i+2];
                        newString[3] = line[i+3];
                        newString[4] = line[i+4];
                        string item = new string(newString);
                        if(item.Equals(arrow1) || item.Equals(arrow2))
                        {
                            count++;
                        }
                    }
                    Console.WriteLine(count);
                }
        }
    }
}
