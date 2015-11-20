using System;
using System.IO;
using System.Text;

namespace TextDollar
{
    class Program
    {
        static string[] text = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety", "Hundred", "Thousand", "Million" };
        static string[] special_text = new string[] { "Zero", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen","Nineteen" };
        static void Main(string[] args)
        {
            using (StreamReader reader = File.OpenText(args[0]))
                while (!reader.EndOfStream)
                {
                    string line = reader.ReadLine();
                    if (null == line)
                        continue;
                    var number = Convert.ToInt64(line);
                    if (line.Length == 1)
                    {
                        Console.WriteLine(oneDigit(Convert.ToInt32(line)));
                    }
                    else if (line.Length == 2)
                    {
                        Console.WriteLine(twoDigit(Convert.ToInt32(line)));
                    }
                    else if (line.Length == 3)
                    {
                        Console.WriteLine(threeDigit(Convert.ToInt32(line)));
                    }
                    else if (line.Length == 4)
                    {
                        Console.WriteLine(fourDigit(Convert.ToInt32(line)));
                    }
                    else if (line.Length == 5)
                    {
                        Console.WriteLine(fiveDigit(Convert.ToInt32(line)));
                    }
                    else if (line.Length == 6)
                    {
                        Console.WriteLine(sixDigit(Convert.ToInt32(line)));
                    }
                    else if (line.Length == 7)
                    {
                        Console.WriteLine(sevenDigit(Convert.ToInt32(line)));
                    }
                    else if (line.Length == 8)
                    {
                        Console.WriteLine(eightDigit(Convert.ToInt64(line)));
                    }
                    else if (line.Length == 9)
                    {
                        Console.WriteLine(nineDigit(Convert.ToInt64(line)));
                    }
                }
        }

        public static string oneDigit(int value)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append(text[value]);
            sb.Append("Dollars");
            return sb.ToString();
        }

        public static string twoDigit(int number)
        {
            StringBuilder sb = new StringBuilder();
            var remainder = number % 10;
            var quotient = number / 10;
            if (remainder == 0)
            {
                sb.Append(text[9 + quotient]);
                sb.Append("Dollars");
            }
            else if (quotient == 0)
            {
                sb.Append(oneDigit(number));
            }
            else if (number > 10 && number < 20)
            {
                sb.Append(special_text[number]);
                sb.Append("Dollars");
            }
            else
            { 
                sb.Append(text[9 + quotient]);
                sb.Append(text[remainder]);
                sb.Append("Dollars");
            }
            return sb.ToString();
        }

        public static string threeDigit(int number)
        {
            StringBuilder sb = new StringBuilder();

            var first_digit = number / 100;
            var middle_digit = (number % 100) / 10;
            var last_digit = number % 10;
            if (first_digit != 0)
            {
                number = number % 100;
                if (middle_digit == 0 && last_digit == 0)
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[19]);
                    sb.Append("Dollars");
                }
                else
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[19]);
                    sb.Append(twoDigit(number));
                }
            }
            else if (first_digit == 0 && middle_digit != 0)
            {
                sb.Append(twoDigit(number));
            }
            else if(first_digit == 0 && middle_digit == 0)
            {
                sb.Append(oneDigit(number));
            }
            return sb.ToString();
        }

        public static string fourDigit(int number)
        {
            StringBuilder sb = new StringBuilder();
            var first_digit = number / 1000;
            var second_digit = (number % 1000) / 100;
            var third_digit = (number % 100) / 10;
            var last_digit = number % 10;

            if (first_digit != 0)
            {
                number %= 1000;
                if (second_digit == 0 && third_digit == 0 && last_digit == 0)
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[20]);
                    sb.Append("Dollars");
                }
                else
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[20]);
                    sb.Append(threeDigit(number));
                }
            }
            else
            {
                sb.Append(threeDigit(number));
            }
            return sb.ToString();
        }

        public static string fiveDigit(int number)
        {
            StringBuilder sb = new StringBuilder();
            var first_digit = number / 10000;
            var second_digit = (number % 10000) / 1000;
            var third_digit = (number % 1000) / 100;
            var fourth_digit = (number % 100) / 10;
            var last_digit = number % 10;

            if (first_digit != 0)
            {
                
                if (second_digit == 0 && third_digit == 0 && fourth_digit == 0 && last_digit == 0)
                {
                    sb.Append(text[9+first_digit]);
                    sb.Append(text[20]);
                    sb.Append("Dollars");
                }
                else if(first_digit == 1 && third_digit == 0 && fourth_digit == 0 && last_digit == 0)
                {
                    var temp = number / 1000;
                    sb.Append(special_text[temp]);
                    sb.Append(text[20]);
                    sb.Append("Dollars");
                }
                else if (first_digit == 1)
                {
                    var temp = number / 1000;
                    var temp1 = number % 1000;
                    sb.Append(special_text[temp]);
                    sb.Append(text[20]);
                    sb.Append(threeDigit(temp1));
                }
                else
                {
                    number %= 10000;
                    if (second_digit == 0)
                    {
                        sb.Append(text[9 + first_digit]);
                        sb.Append(text[20]);
                        sb.Append(fourDigit(number));
                    }
                    else
                    {
                        sb.Append(text[9 + first_digit]);
                        sb.Append(fourDigit(number));
                    }
                }
            }
            else
            {
                sb.Append(fourDigit(number));
            }
            return sb.ToString();
        }

        public static string sixDigit(int number)
        {
            StringBuilder sb = new StringBuilder();
            var first_digit = number / 100000;
            var second_digit = (number % 100000) / 10000;
            var third_digit = (number % 10000) / 1000;
            var fourth_digit = (number % 1000) / 100;
            var fifth_digit = (number % 100) / 10;
            var last_digit = number % 10;

            if (first_digit != 0)
            {
                number %= 100000;
                if (second_digit == 0 && third_digit == 0 && fourth_digit == 0 && fifth_digit == 0&& last_digit == 0)
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[19]);
                    sb.Append(text[20]);
                    sb.Append("Dollars");
                }
                else
                {
                    if (second_digit == 0 && third_digit == 0)
                    {
                        sb.Append(text[first_digit]);
                        sb.Append(text[19]);
                        sb.Append(text[20]);
                        sb.Append(fiveDigit(number));
                    }
                    else
                    {
                        sb.Append(text[first_digit]);
                        sb.Append(text[19]);
                        sb.Append(fiveDigit(number));
                    }
                }
            }
            else
            {
                sb.Append(fiveDigit(number));
            }
            return sb.ToString();
        }

        public static string sevenDigit(int number)
        {
            StringBuilder sb = new StringBuilder();
            var first_digit = number / 1000000;
            var second_digit = (number % 1000000) / 100000;
            var third_digit = (number % 100000) / 10000;
            var fourth_digit = (number % 10000) / 1000;
            var fifth_digit = (number % 1000) / 100;
            var sixth_digit = (number % 100) / 10;
            var last_digit = number % 10;

            if (first_digit != 0)
            {
                number %= 1000000;
                if (second_digit == 0 && third_digit == 0 && fourth_digit == 0 && fifth_digit == 0 && sixth_digit==0 && last_digit == 0)
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[21]);
                    sb.Append("Dollars");
                }
                else
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[21]);
                    sb.Append(sixDigit(number));
                }
            }
            else
            {
                sb.Append(sixDigit(number));
            }
            return sb.ToString();
        }

        public static string eightDigit(long number)
        {
            StringBuilder sb = new StringBuilder();
            var first_digit = number / 10000000;
            var second_digit = (number % 10000000) / 1000000;
            var third_digit = (number % 1000000) / 100000;
            var fourth_digit = (number % 100000) / 10000;
            var fifth_digit = (number % 10000) / 1000;
            var sixth_digit = (number % 1000) / 100;
            var seventh_digit = (number % 100) / 10;
            var last_digit = number % 10;

            if (first_digit != 0)
            {
                
                if (second_digit == 0 && third_digit == 0 && fourth_digit == 0 && fifth_digit == 0 && sixth_digit == 0 && seventh_digit == 0 && last_digit == 0)
                {
                    sb.Append(text[9+first_digit]);
                    sb.Append(text[21]);
                    sb.Append("Dollars");
                }
                else if (first_digit == 1 && third_digit == 0 && fourth_digit == 0 &&fifth_digit == 0 && sixth_digit == 0 && seventh_digit == 0 && last_digit == 0)
                {
                    var temp = number / 1000000;
                    sb.Append(special_text[temp]);
                    sb.Append(text[21]);
                    sb.Append("Dollars");
                }
                else if (first_digit == 1)
                {
                    var temp = number / 1000000;
                    var temp1 = (int)number % 1000000;
                    sb.Append(special_text[temp]);
                    sb.Append(text[21]);
                    sb.Append(sixDigit(temp1));
                }
                else
                {
                    number %= 10000000;
                    if (second_digit == 0)
                    {
                        sb.Append(text[9 + first_digit]);
                        sb.Append(text[21]);
                        sb.Append(sevenDigit(Convert.ToInt32(number)));
                    }
                    else
                    {
                        sb.Append(text[9 + first_digit]);
                        sb.Append(sevenDigit(Convert.ToInt32(number)));
                    }
                }
            }
            else
            {
                sb.Append(sevenDigit(Convert.ToInt32(number)));
            }
            return sb.ToString();
        }

        public static string nineDigit(long number)
        {
            StringBuilder sb = new StringBuilder();
            var first_digit = number / 100000000;
            var second_digit = (number % 100000000) / 10000000;
            var third_digit = (number % 10000000) / 1000000;
            var fourth_digit = (number % 1000000) / 100000;
            var fifth_digit = (number % 100000) / 10000;
            var sixth_digit = (number % 10000) / 1000;
            var seventh_digit = (number % 1000) / 100;
            var eighth_digit = (number % 100) / 10;
            var last_digit = number % 10;

            if (first_digit != 0)
            {
                number %= 100000000;
                if (second_digit == 0 && third_digit == 0 && fourth_digit == 0 && fifth_digit == 0 && sixth_digit == 0 && seventh_digit == 0 && eighth_digit == 0 && last_digit == 0)
                {
                    sb.Append(text[first_digit]);
                    sb.Append(text[19]);
                    sb.Append(text[21]);
                    sb.Append("Dollars");
                }
                else
                {
                    if (second_digit == 0 && third_digit == 0)
                    {
                        sb.Append(text[first_digit]);
                        sb.Append(text[19]);
                        sb.Append(text[21]);
                        sb.Append(eightDigit(number));
                    }
                    else
                    {
                        sb.Append(text[first_digit]);
                        sb.Append(text[19]);
                        sb.Append(eightDigit(number));
                    }
                }
            }
            else
            {
                sb.Append(eightDigit(number));
            }
            return sb.ToString();
        }

    }
}
