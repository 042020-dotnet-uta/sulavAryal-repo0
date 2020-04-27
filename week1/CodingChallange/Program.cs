using System;

namespace CodingChallange
{
    class Program
    {
        static void Main()
        {
            // Creates an instance of CalculateSweetnSalts class 
            CalculateSweetnSalts calc = new CalculateSweetnSalts();
            // invokes the Calculate method of CalculateSweenSalts class. 
            calc.Calculate();

            // Creates a new Class instance of Counts class 
            // and prints it.
            Counts counts = new Counts();
            // It will print becuase of the overriden ToString method in Counts's class defination itself. 
            Console.WriteLine(counts);
        }  
    }

        
}
