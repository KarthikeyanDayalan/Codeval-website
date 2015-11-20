using System;
using System.IO;
using System.Text;

namespace DataRecovery
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
                    var input = line.Split(';');
                    var text = input[0].Split(' ');
                    var value = input[1].Split(' ');
                    string[] output = new string[text.Length];
                    byte[] flag = new byte[text.Length];
                    int j = 0;
                    foreach (var item in value)
                    {
                        output[Convert.ToInt32(item) - 1] = text[j];
                        flag[Convert.ToInt32(item) - 1] = 1;
                        j++;
                    }
                    j = value.Length;
                    for (int i = 0; i < flag.Length; i++)
                    {
                        if(flag[i] == 0)
                        {
                            output[i] = text[j];
                            j++;
                        }
                    }

                    for (int i = 0; i < output.Length; i++)
                    {
                        Console.Write(output[i]+ " ");
                    }
                    Console.WriteLine();
                }
        }
    }
}
