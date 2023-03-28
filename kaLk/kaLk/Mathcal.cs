using Accessibility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;

namespace kaLk
{
    public class Mathcal
    {
        public double[] ParserN(string primer)
        {
            string numbersString = "";
            double[] numbers;

            for (int i = 0; i < primer.Length; i++)
            {
                if (primer[i] == '+' || primer[i] == '-' || primer[i] == '*' || primer[i] == '/' || primer[i] == '+')
                    numbersString += ";";
                else
                    numbersString += primer[i];
            }
            numbers = numbersString.Split(';').Select(s => double.TryParse(s, out double n) ? n : 0).ToArray();
            return numbers;
        }
        public char[] ParserC(string primer)
        {
            string chars = "";
            for (int i = 0; i < primer.Length; i++)
            {
                if (primer[i] == '+')
                    chars += "+";
                if (primer[i] == '-')
                    chars += "-";
                if (primer[i] == '*')
                    chars += "*";
                if (primer[i] == '/')
                    chars += "/";
            }
            return chars.ToCharArray();
        }
        public double[] DeleteE(double[] array, int index)
        {
            double[] doubles = new double[array.Length - 1];
            for (int i = 0, j = 0; i < doubles.Length; j++, i++)
            {
                if (i == index)
                {
                    j++;
                }
                doubles[i] = array[j];
            }
            return doubles;
        }

        public string[] DeleteE(string[] array, int index)
        {
            string[] strings = new string[array.Length - 1];
            for (int i = 0, j = 0; i < strings.Length; j++, i++)
            {
                if (i == index)
                {
                    j++;
                }
                strings[i] = array[j];
            }
            return strings;
        }

        public char[] DeleteE(char[] array, int index)
        {
            char[] chars = new char[array.Length - 1];
            for (int i = 0, j = 0; i < chars.Length; j++, i++)
            {
                if (i == index)
                {
                    j++;
                }
                chars[i] = array[j];
            }
            return chars;
        }


        public double Calculate(double[] numbers, char[] simbols)
        {
            double result = 0;

            for (int i = 0; i < simbols.Length; i++)
            {
                if (simbols[i] == '*' || simbols[i] == '/')
                {
                    if (simbols[i] == '*')
                    {
                        numbers[i + 1] = numbers[i] * numbers[i + 1];
                    }
                    else
                    {
                        numbers[i + 1] = numbers[i] / numbers[i + 1];
                    }
                    numbers = DeleteE(numbers, i);
                    simbols = DeleteE(simbols, i);
                    i--;
                }
            }

            for (int i = 0; i < simbols.Length; i++)
            {
                if (simbols[i] == '+' || simbols[i] == '-')
                {
                    if (simbols[i] == '+')
                    {
                        numbers[i + 1] = numbers[i] + numbers[i + 1];
                    }
                    else
                    {
                        numbers[i + 1] = numbers[i + 1] - numbers[i];
                    }
                    numbers = DeleteE(numbers, i);
                    simbols = DeleteE(simbols, i);
                    i--;
                }
            }
            for (int i = 0; i < numbers.Length; i++)
            {
                result += numbers[i];
            }
            return result;
        }
    }
}