using System;
using System.Collections.Generic;
using System.IO;

namespace Blackcard
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
                    string[] input = line.Trim().Split('|');
                    string[] names = input[0].Trim().Split(' ');
                    int count = 0;
                    //List<string> list = new List<string>();
                    LinkedList<string> llist = new LinkedList<string>();
                    for(int i = 0; i < names.Length; i++)
                    {
                        llist.AddLast(names[i]);
                    }
                    while (llist.Count > 1)
                    {
                        var node = llist.First;
                        while(node!= null)
                        {
                            var nextnode = node.Next;                        
                            count++;
                            if (count == Convert.ToInt32(input[1]))
                            {
                                llist.Remove(node);
                                count = 0;
                                break;
                            }
                            node = nextnode;
                        }
                    }

                    foreach (var item in llist)
                    {
                        Console.WriteLine(item);
                    }

                }
        }
    }
}
