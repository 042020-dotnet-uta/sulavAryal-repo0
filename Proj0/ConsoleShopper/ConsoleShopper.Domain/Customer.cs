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
        public string Password { get; set; }

        #region Commented password Encode/Decode Routine to be implemented later
        //public string Password
        //{
        //    get {


        //        return password;
        //    }
        //    set {

        //        // Highly inscecure. don't do this in production or at home.
        //        // Stay safe, stay secure, remember to salt your hashes just like your food. 
        //        // and use strong encryption.
        //        // Used here only for Demo purposes. 
        //        //string hash = "";
        //        password = value;
        //    }
        //}
        #endregion  

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public override string ToString()
        {
            return $"Customer Details : \nId: {Id} \nFirst Name: {FirstName} \nLast Name: {LastName}";
        }
    }
}
