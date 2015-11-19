using System;
using System.Collections.Generic;
using System.IO;

namespace QueryBoard
{
    class Program
    {
        static void Main(string[] args)
        {
            byte[,] board = new byte[256, 256];
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    
                    //Array.Clear(board, 0, 255 * 255);
                    string[] input = line.Split(' ');
                    string sc = "SetCol";
                    string sr = "SetRow";
                    string qc = "QueryCol";
                    string qr = "QueryRow";
                    int sum = 0;
                    if(input[0].Equals(sc))
                    {
                        for(int j = 0 ; j < 256; j++)
                        {
                            board[j, Convert.ToInt32(input[1])] = Convert.ToByte(input[2]);
                        }
                    }
                    else if (input[0].Equals(sr))
                    {
                        for (int j = 0; j < 256; j++)
                        {
                            board[Convert.ToInt32(input[1]),j] = Convert.ToByte(input[2]);
                        }

                    }
                    else if (input[0].Equals(qc))
                    {
                        for (int i = 0; i < 256; i++)
                        {
                            sum += board[i,Convert.ToInt32(input[1])];
                        }
                        Console.WriteLine(sum);
                    }
                    else if (input[0].Equals(qr))
                    {
                        for (int i = 0; i < 256; i++)
                        {
                            sum += board[Convert.ToInt32(input[1]),i];
                        }
                        Console.WriteLine(sum);
                    }
                }
        }
    }
}
