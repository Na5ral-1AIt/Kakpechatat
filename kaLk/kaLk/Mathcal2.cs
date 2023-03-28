using System;
using System.Linq;

namespace kaLk
{
    internal class Mathcal2
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
            if (primer[0] == '-')
                numbers[1] *= -1;
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

        public double Calculate(string expression)
        {
            int startIndex = expression.IndexOf("(");

            if (startIndex < 0)
            {
                return ParseExpression(expression);
            }

            int endIndex = FindMatchingBracket(expression, startIndex);

            double inside = Calculate(expression.Substring(startIndex + 1, endIndex - startIndex - 1));

            expression = expression.Substring(0, startIndex) + inside.ToString() + expression.Substring(endIndex + 1);

            return Calculate(expression);
        }

        private double ParseExpression(string expression)
        {
            double[] numbers = ParserN(expression);
            char[] operators = ParserC(expression);

            for (int i = 0; i < operators.Length; i++)
            {
                if (operators[i] == '*' || operators[i] == '/')
                {
                    if (operators[i] == '*')
                    {
                        numbers[i + 1] = numbers[i] * numbers[i + 1];
                    }
                    else
                    {
                        numbers[i + 1] = numbers[i] / numbers[i + 1];
                    }
                    numbers = DeleteE(numbers, i);
                    operators = DeleteE(operators, i);
                    i--;
                }
            }

            for (int i = 0; i < operators.Length; i++)
            {
                if (operators[i] == '+' || operators[i] == '-')
                {
                    if (operators[i] == '+')
                    {
                        numbers[i + 1] = numbers[i] + numbers[i + 1];
                    }
                    else
                    {
                        numbers[i + 1] = numbers[i] - numbers[i + 1];
                    }
                    numbers = DeleteE(numbers, i);
                    operators = DeleteE(operators, i);
                    i--;
                }
            }
            return numbers[0];
        }

        private int FindMatchingBracket(string expression, int startIndex)
        {
            int count = 0;
            for (int i = startIndex; i < expression.Length; i++)
            {
                if (expression[i] == '(')
                {
                    count++;
                }
                else if (expression[i] == ')')
                {
                    count--;
                    if (count == 0)
                    {
                        return i;
                    }
                }
            }
            throw new ArgumentException("??? -> {0}", expression);
        }

    }
}