using System;
using System.Threading;

namespace CodingChallangeWeek3
{
    class Program
    {
        static void Main(string[] args)
        {
            IsEven isEven = new IsEven();
            Multiplication mult = new Multiplication();
            Alternate alt = new Alternate();
            while (true) 
            {
                Console.WriteLine("***************************Welcome to week 3 challanges**********************");
                Console.WriteLine("Press 1 to go to \"Is the Even\" challange");
                Console.WriteLine("Press 2 to go to \"Multiplication table\" challange");
                Console.WriteLine("Press 3 to go to \"Alternating Elements \" challange\n");
                Console.WriteLine("Write exit and press enter to exit");
                Console.Write("Enter your choice: ");
                var input = Console.ReadLine();
                if (input == "1")
                {
                    isEven.CalculateIsEven();
                }
                else if (input == "2")
                {
                    mult.MultTable();
                }
                else if (input == "3")
                {
                    alt.Shuffle();
                }
                else if (input.Trim().ToLower() == "exit") 
                {
                    Console.WriteLine("Thank you for your time. Bye...");
                    Thread.Sleep(3000);
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}
