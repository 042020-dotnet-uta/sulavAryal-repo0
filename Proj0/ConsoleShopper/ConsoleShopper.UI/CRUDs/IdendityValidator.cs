using System;
using System.Threading.Tasks;

namespace ConsoleShopper.UI
{
    public static class IdendityValidator
    {
        static string[]  UserInput() 
        {
            string[] inputs = new string[2];
            Console.Write("\nEnter your username: ");
            inputs[0] = Console.ReadLine();
            Console.Write("Enter your password: ");
            inputs[1] = Console.ReadLine();
            return inputs;
        }
        public static async Task<bool> IsAdmin() 
        {
            var inputs = UserInput();
            CustomerCRUD CustomerCRUD = new CustomerCRUD();
            if (!await CustomerCRUD.IsAdmin(inputs[0], inputs[1]))
            {
                Console.WriteLine("Sorry you don't have the authority to do this.");
                return false;
            }
            return true;
        }
       
    }
}
