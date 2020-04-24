using System;
using System.Collections.Generic;
using System.Linq;

namespace lamdaExample
{
    class Dog 
    {
        public int Id { get; set; }
        public string Breed { get; set; }
    }
     class Program
    {
        static void Main(string[] args)
        {
            List<Dog> dogBreeds = new List<Dog>
            {
                new Dog
                {
                    Id = 1,
                    Breed = "English Toy Spaniel"
                },
                new Dog
                {
                    Id = 2,
                    Breed = "Tibetan Mastiff "
                },
                new Dog
                {
                    Id = 3,
                    Breed = "Anatolian Shepard Dog"
                },
                new Dog
                {
                    Id = 4,
                    Breed = "Finnish Lapphund"
                },
                new Dog
                {
                    Id = 5,
                    Breed = "Yorkshire Terrier"
                },

            };
            var orderedDogs = dogBreeds.OrderByDescending(x => x.Breed);
            foreach (Dog d in orderedDogs) 
            {
                Console.WriteLine(d.Breed);
            }

        }
    }
}
