using System;
using System.Collections.Generic;
using System.IO;


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
                    Console.WriteLine(line);
                    line = line.Trim();
                    string output = string.Empty;
                    if(line.Length <= 55)
                    {
                        Console.WriteLine(line);
                    }
                    else
                    {
                        int lastspace = 0;
                        output = line.Substring(0, 40);
                        lastspace = output.LastIndexOf(" ");                       
                        if(lastspace <= 0)
                            output = line.Substring(0, 40) + "... <Read More>";
                        else
                            output = line.Substring(0, lastspace).Trim() + "... <Read More>";
                        Console.WriteLine(output);
                    }
                }            
        }
    }

