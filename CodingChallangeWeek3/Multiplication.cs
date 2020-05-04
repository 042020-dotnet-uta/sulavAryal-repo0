using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace CodingChallangeWeek3
{
    public class Multiplication
    {
        /*
         *   “Multiplication Table” - Write a method called MultTable() to get an Integer from the user, validate it, 
         *   and print a multiplication table to the console. If the input is invalid, tell the user and have them retry till they get it right. 
         *   Ex.  given 3, print to the screen -  1 x 1 = 1, 1 x 2 = 2, 1 x 3 = 3, 2 x 1 = 2, 2 x 2 = 4, 2 x 3 = 6, 3 x 1 = 3, 3 x 2 = 6, 3 x 3 = 9. 
         * 
        */
        /// <summary>
        /// Asks for users input, converts it into number then loops through displaying multiplication table. 
        /// </summary>
        public void MultTable()
        {
            while (true)
            {
                Console.Write("Enter an integer for your table of multiplication: ");
                var input = Console.ReadLine();
                var inputInt = 0;
                if (!Int32.TryParse(input, out inputInt))
                {
                    Console.WriteLine("Invalid input, Please try again.");
                    Thread.Sleep(2000);
                    continue;
                }
                for (int i = 0; i < inputInt; i++)
                {
                    Console.WriteLine($"\nMultiplication table of {i + 1}");
                    for (int j = 0; j < inputInt; j++)
                    {
                        Console.WriteLine($"{i + 1} x {j + 1} = {(i + 1) * (j + 1)}");
                    }
                }
                return;
            }
        }
    }
}
