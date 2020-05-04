using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CodingChallangeWeek3
{
    public class Alternate
    {
        /// <summary>
        /// Takes in two List of string arrays
        /// merging them together 
        /// </summary>
        public void Shuffle()
        {

            while (true)
            {
                // Creating two list of string
                List<string> arr1 = new List<string>();
                List<string> arr2 = new List<string>();

                Console.WriteLine("*************************Welcome to Shuffle menu****************************");

                // loop through adding user inputs into the list. 
                var input = "";
                for (int i = 0; i < 5; i++)
                {
                    Console.Write($"Enter your input item for first array: ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input)) 
                    {
                        arr1.Add(input);
                        
                    }
                    continue;
                }
                // loop through adding user inputs into second list. 
                for (int j = 0; j < 5; j++)
                {

                    Console.Write($"Enter your input item for second array: ");
                    input = Console.ReadLine();
                    if (!string.IsNullOrWhiteSpace(input))
                    {
                        arr2.Add(input);
                    }
                    continue;
                }

                // creates third list preparing for the merge. 
                List<string> mergedArray = new List<string>();

                // help sought and  Michael & JD helped me here. 
                // loops through and adds previously stored user inputs one by one into the 
                // newly created array. 
                for (int i = 0; i < 5; i++)
                {
                    mergedArray.Add(arr1[i]);
                    mergedArray.Add(arr2[i]);
                }

                // loops through to get the memebers of array printed.  
                foreach (string s in mergedArray)
                {
                    Console.Write($"{s}\t");
                }
                Console.WriteLine("");
                return;
            }

        }
    }
}
