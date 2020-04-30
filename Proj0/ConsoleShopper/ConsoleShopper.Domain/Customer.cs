using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace ConsoleShopper.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }


        private string password;
        [StringLength(16)]
        public string Password
        {
            get { 
                return password;
            }
            set { 
                password = value;
            }
        }

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public override string ToString()
        {
            return $"Customer Details : \nId: {Id} \nFirst Name: {FirstName} \nLast Name: {LastName}";
        }
    }
}
