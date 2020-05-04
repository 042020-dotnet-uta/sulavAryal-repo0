using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallangeWeek3
{
    public class IsEven
    {
        /// <summary>
        /// Asks for user input, converts it into number, then check to see if is even. 
        /// </summary>
        public void CalculateIsEven()
        {
            Console.WriteLine("**********************This is where you can even your odds **********************");
            Console.Write("Enter first number: ");
            var stringInput = Console.ReadLine();
            // sanitizes user input
            if (!string.IsNullOrWhiteSpace(stringInput))
            {
                // tries converting string input into int
                int input = 0;
                if (Int32.TryParse(stringInput, out input))
                {
                    // checks even/odd sets the message accordingly
                    var result = input % 2 == 0 ? "That number is even." : $"{input} is not an even number";
                    Console.WriteLine(result);
                    return;
                }
                else
                {
                    // returns to main menu if the input is string. 
                    Console.WriteLine($"{stringInput} is a string, not a number");
                    return;
                }
            }
          
        }
    }
}
