using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallange
{
    class CalculateSweetnSalts
    {

        // based on https://www.c-sharpcorner.com/blogs/fizzbuzz-in-c-sharp
        public void Calculate()
        {
            // loops through number from 1 till 100

            for (int i = 1; i <= 100; i++)
            {
                // prints sweet’nSalty if the number is divisible by both 5 and 3
                // increases count of CountSaltnSweet by 1 everytime
                if (i % 3 == 0 && i % 5 == 0)
                {
                    Counts.CountSaltnSweets++;
                    Console.WriteLine("sweet’nSalty");
                }

                // prints Sweet if the number is divisible by 3
                // increases count of CountSweet by 1 everytime
                else if (i % 3 == 0)
                {
                    Counts.CountSweets++;
                    Console.WriteLine("Sweet");
                }

                // prints Salty if the number is divisible by 3
                // increases count of CountSweet by 1 everytime
                else if (i % 5 == 0)
                {
                    Counts.CountSalts++;
                    Console.WriteLine("Salty");
                }
                // prints the current value of i
                else
                {
                    Console.WriteLine(i);
                }
            }
          
        }
    }
}
