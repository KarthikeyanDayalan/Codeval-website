using System;
using System.IO;
using System.Text;

namespace Pointinacircle
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
                    string[] input = line.Trim().Split(';');
                    StringBuilder c1 = new StringBuilder();
                    StringBuilder c2 = new StringBuilder();
                    StringBuilder radius = new StringBuilder();
                    StringBuilder p1 = new StringBuilder();
                    StringBuilder p2 = new StringBuilder();
                    int flag = 0;
                    for (int i = 0; i < input[0].Length; i++)
                    {
                        if (input[0][i] == 44)
                            flag = 1;
                        if(flag == 0 && ((input[0][i] == 46) || (input[0][i] == 45) || (input[0][i] >=48 && input[0][i] <= 57)))
                        {
                            c1.Append(input[0][i]);
                        }
                        else if (flag == 1 && ((input[0][i] == 46) || (input[0][i] == 45) || (input[0][i] >= 48 && input[0][i] <= 57)))
                        {
                            c2.Append(input[0][i]);
                        }
                    }

                    flag = 0;
                    for (int i = 0; i < input[2].Length; i++)
                    {
                        if (input[2][i] == 44)
                            flag = 1;
                        if (flag == 0 && ((input[2][i] == 46) || (input[2][i] == 45) || (input[2][i] >= 48 && input[2][i] <= 57)))
                        {
                            p1.Append(input[2][i]);
                        }
                        else if (flag == 1 && ((input[2][i] == 46) || (input[2][i] == 45) || (input[2][i] >= 48 && input[2][i] <= 57)))
                        {
                            p2.Append(input[2][i]);
                        }
                    }
                    
                    for (int i = 0; i < input[1].Length; i++)
                    {
                        if (((input[1][i] == 46) || (input[1][i] == 45) || (input[1][i] >= 48 && input[1][i] <= 57)))
                        {
                            radius.Append(input[1][i]);
                        }
                    }

                    double x1 = Convert.ToDouble(c1.ToString());
                    double x2 = Convert.ToDouble(c2.ToString());
                    double y1 = Convert.ToDouble(p1.ToString());
                    double y2 = Convert.ToDouble(p2.ToString());
                    double r = Convert.ToDouble(radius.ToString());

                    if(Math.Pow(r,2) >= (Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)))
                    {
                        Console.WriteLine("true");
                    }
                    else if (Math.Pow(r,2) < (Math.Pow((x2 - x1), 2) + Math.Pow((y2 - y1), 2)))
                    {
                        Console.WriteLine("false");
                    }
                }
        }
    }
}
