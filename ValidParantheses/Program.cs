using System;
using System.Collections.Generic;
using System.IO;

namespace ValidParantheses
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
                    
                    line = line.Trim();
                    Stack<char> paran = new Stack<char>();
                    int flag = 0;
                    for(int i = 0; i < line.Length; i++)
                    {
                        if(line[i] == '(' || line[i] == '{' || line[i] == '[')
                        {
                            paran.Push(line[i]);
                        }
                        else
                        {
                            if(paran.Count > 0)
                            {
                                char ch = paran.Pop();
                            
                                if (line[i] == ')' && ch != '(')
                                {
                                    flag = 1;
                                    Console.WriteLine("False");
                                    break;
                                }
                                else if (line[i] == ']' && ch != '[')
                                {
                                    flag = 1;
                                    Console.WriteLine("False");
                                    break;
                                }
                                else if (line[i] == '}' && ch != '{')
                                {
                                    flag = 1;
                                    Console.WriteLine("False");
                                    break;
                                }
                            }
                            else
                            {
                                flag = 1;
                                Console.WriteLine("False");
                                break;
                            }
                        }
                    }
                    if(flag == 0 && paran.Count == 0)
                        Console.WriteLine("True");
                    else if (flag == 0 && paran.Count != 0)
                        Console.WriteLine("False");
                }
        }
    }
}