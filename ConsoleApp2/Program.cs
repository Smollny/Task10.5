using System;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            SumTwoNumbers sumTwoNumbers = new SumTwoNumbers(Console.ReadLine(), Console.ReadLine());
            Console.WriteLine("Результат: " + sumTwoNumbers.Sum());
            Console.ReadKey();
        }
    }
    
    class SumTwoNumbers : ISumTwoNumbers
    {
        private double num1, num2;
        private Logger logger;

        public SumTwoNumbers(string n1, string n2)
        {
            logger = new Logger();
            num1 = StrToDouble(n1);
            num2 = StrToDouble(n2);
        }

        double StrToDouble(string number)
        {
            double num = double.NaN;
            try
            {
                num = double.Parse(number);
                logger.Write($"Введенное число: {num}", ConsoleColor.Blue);
            }
            catch (Exception ee)
            {
                logger.Write(ee.Message, ConsoleColor.Red);
            }
            return num;
        }

        public double Sum()
        {
            if (!double.IsNaN(num1) && !double.IsNaN(num2)) 
                return num1 + num2; 
            else return double.NaN;
        }
    }

    interface ISumTwoNumbers
    {
        double Sum();
    }

    interface ILogger
    {
        void Write(string message, ConsoleColor color);
    }

    public class Logger : ILogger
    {
        public void Write(string message, ConsoleColor color)
        {
            Console.ForegroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
    }
}
