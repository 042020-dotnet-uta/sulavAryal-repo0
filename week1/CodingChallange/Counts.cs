using System;
using System.Collections.Generic;
using System.Text;

namespace CodingChallange
{
    class Counts
    {

        // property for storing counts of Sweets 
        public static int CountSweets { get; set; }
        // property for storing counts of Salts
        public static int CountSalts { get; set; }
        // property for storing counts of SweetnSalts
        public static int CountSaltnSweets { get; set; }

        // overriden ToString method to properly print all the counts of Sweet, Salt and SweetnSalts
        public override string ToString()
        {
            return $"There are {Counts.CountSweets} sweet's {Counts.CountSalts} salty's and {Counts.CountSaltnSweets} sweet’nSalty’s";
        }
    }
}
