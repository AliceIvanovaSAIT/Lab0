using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace Lab0
{
    internal class Program
    {
        static void Main(string[] args)
        {

            double lowNumber = GetLowNumber();
            lowNumber = ValidateLowNumber(lowNumber);

            double highNumber = GetHighNumber(lowNumber);
            highNumber = ValidateGreaterNumber(highNumber, lowNumber);

            double difference = highNumber - lowNumber;
            Console.WriteLine($"This is the difference between numbers: {difference}");

            List<double> numbers = new List<double>();

            for (int i = Convert.ToInt32(lowNumber); i <= highNumber; i++)
            {
                numbers.Add(i);
            }

            
            numbers.Reverse();


            String filepath = @"C:\Users\ivano\SAIT\semester 2\CPRG-211-E (oop)\Lab0\Lab0\numbers.txt";
            List<String> fileNumbers = new List<string>();
            fileNumbers = File.ReadAllLines(filepath).ToList();
            
            using (StreamWriter file = new StreamWriter("numbers.txt"))
            {
                foreach (double number in numbers)
                {
                    fileNumbers.Add(Convert.ToString(number));
                }
            }
            
            foreach (double number in numbers)
            {
                bool IsNumberPrime = PrimeNumber(number);
                if (IsNumberPrime)
                {
                    Console.WriteLine($"{number} is prime");
                }
                else
                {
                    Console.WriteLine($"{number} isn't prime");
                }
            }

            Console.ReadLine();
        }

       static double GetLowNumber()
       {

            Console.Write("Enter a positive low number: ");
            double lowNumber = Convert.ToDouble(Console.ReadLine());

            return lowNumber;
       }

        static double ValidateLowNumber(double lowNumber)
        {
            while (lowNumber < 0)
            {
                if (lowNumber<0)
                {
                    Console.WriteLine("This number is not greater.");
                    lowNumber = GetLowNumber();
                    
                }
                else
                {
                    Console.WriteLine("Thank you");
                    
                }
            }
            return lowNumber;
        }

        static double GetHighNumber(double lowNumber)
        {

            Console.Write($"Enter a greater number than {lowNumber}: ");
            double highNumber = Convert.ToDouble(Console.ReadLine());

            return highNumber;
        }

        static double ValidateGreaterNumber(double highNumber, double lowNumber)
        {
            while (highNumber <= lowNumber)
            {
                if (highNumber <= lowNumber)
                {
                    Console.WriteLine("This number is not greater.");
                    highNumber = GetHighNumber(lowNumber);
                }
                else
                {
                    Console.WriteLine("Thank you");
                }
            }

            return highNumber;
        }

        static bool PrimeNumber(double number)
        {
            bool primeNumber = true;
            for (int i = 2; i < number; i++)
            {
                if ((number % i) == 0)
                {
                    primeNumber = false;
                    break;
                }
            }

            return primeNumber;
        }
    }
}
