using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Numberpairs
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
                    string[] input = line.Split(';');
                    string[] values = input[0].Split(',');
                    int i = 0, j = values.Length - 1;
                    StringBuilder sb = new StringBuilder();
                    while(i < j)
                    {
                        if (Convert.ToInt32(values[i]) + Convert.ToInt32(values[j]) == Convert.ToInt32(input[1]))
                        {
                            sb.Append(values[i]);
                            sb.Append(',');
                            sb.Append(values[j]);
                            sb.Append(';');
                            i++;
                            j--;
                        }
                        else if(Convert.ToInt32(values[i]) + Convert.ToInt32(values[j]) < Convert.ToInt32(input[1]))
                        {
                            i++;
                        }
                        else if (Convert.ToInt32(values[i]) + Convert.ToInt32(values[j]) > Convert.ToInt32(input[1]))
                        {
                            j--;
                        }
                    }
                    if (sb.Length != 0)
                        sb.Remove(sb.Length - 1, 1);
                    else
                        sb.Append("NULL");
                    Console.WriteLine(sb);
                }
        }
    }
}
