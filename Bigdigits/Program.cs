using System;
using System.Collections.Generic;
using System.IO;

namespace Bigdigits
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
                    char[,] zero = new char[,] {    {'-','*','*','-','-'},
                                                    {'*','-','-','*','-'},
                                                    {'*','-','-','*','-'},
                                                    {'*','-','-','*','-'},
                                                    {'-','*','*','-','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] one = new char[,] {     {'-','-','*','-','-'},
                                                    {'-','*','*','-','-'},
                                                    {'-','-','*','-','-'},
                                                    {'-','-','*','-','-'},
                                                    {'-','*','*','*','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] two = new char[,] {     {'*','*','*','-','-'},
                                                    {'-','-','-','*','-'},
                                                    {'-','*','*','-','-'},
                                                    {'*','-','-','-','-'},
                                                    {'*','*','*','*','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] three = new char[,] {   {'*','*','*','-','-'},
                                                    {'-','-','-','*','-'},
                                                    {'-','*','*','-','-'},
                                                    {'-','-','-','*','-'},
                                                    {'*','*','*','-','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] four = new char[,] {    {'-','*','-','-','-'},
                                                    {'*','-','-','*','-'},
                                                    {'*','*','*','*','-'},
                                                    {'-','-','-','*','-'},
                                                    {'-','-','-','*','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] five = new char[,] {    {'*','*','*','*','-'},
                                                    {'*','-','-','-','-'},
                                                    {'*','*','*','-','-'},
                                                    {'-','-','-','*','-'},
                                                    {'*','*','*','-','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] six = new char[,] {     {'-','*','*','-','-'},
                                                    {'*','-','-','-','-'},
                                                    {'*','*','*','-','-'},
                                                    {'*','-','-','*','-'},
                                                    {'-','*','*','-','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] seven = new char[,] {   {'*','*','*','*','-'},
                                                    {'-','-','-','*','-'},
                                                    {'-','-','*','-','-'},
                                                    {'-','*','-','-','-'},
                                                    {'-','*','-','-','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] eight = new char[,] {   {'-','*','*','-','-'},
                                                    {'*','-','-','*','-'},
                                                    {'-','*','*','-','-'},
                                                    {'*','-','-','*','-'},
                                                    {'-','*','*','-','-'},
                                                    {'-','-','-','-','-'}};
                    char[,] nine = new char[,] {    {'-','*','*','-','-'},
                                                    {'*','-','-','*','-'},
                                                    {'-','*','*','*','-'},
                                                    {'-','-','-','*','-'},
                                                    {'-','*','*','-','-'},
                                                    {'-','-','-','-','-'}};

                    List<List<char>> output = new List<List<char>>();
                    int count = 0;
                    for(int i = 0; i < line.Length; i++)
                    {
                        if(line[i] == 48)
                        {
                            output = mergearrays(output, zero);
                            count++;
                        }
                        else if (line[i] == 49)
                        {
                            output = mergearrays(output, one);
                            count++;
                        }
                        else if (line[i] == 50)
                        {
                            output = mergearrays(output, two);
                            count++;
                        }
                        else if (line[i] == 51)
                        {
                            output = mergearrays(output, three);
                            count++;
                        }
                        else if (line[i] == 52)
                        {
                            output = mergearrays(output, four);
                            count++;
                        }
                        else if (line[i] == 53)
                        {
                            output = mergearrays(output, five);
                            count++;
                        }
                        else if (line[i] == 54)
                        {
                            output = mergearrays(output, six);
                            count++;
                        }
                        else if (line[i] == 55)
                        {
                            output = mergearrays(output, seven);
                            count++;
                        }
                        else if (line[i] == 56)
                        {
                            output = mergearrays(output, eight);
                            count++;
                        }
                        else if (line[i] == 57)
                        {
                            output = mergearrays(output, nine);
                            count++;
                        }
                    }
                    foreach (var item in output)
                    {
                        foreach (var i in item)
                        {
                            Console.Write(i);
                        }
                        Console.WriteLine();
                    }
                }
        }

        public static List<List<char>> mergearrays(List<List<char>> List, char[,] b)
        {
            int k = 0;
            if (List.Count == 0)
            {
                for(int i = 0 ; i < 6; i++)
                {
                    List<char> temp = new List<char>();
                    for (int j = 0; j < 5; j++)
                    {
                        temp.Add(b[i,j]);
                    }
                    List.Add(temp);
                }
            }
            else
            {
                foreach (var item in List)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        item.Add(b[k, j]);
                    }
                    k++;
                }
            }
            return List;
        }
    }
}
