using System.ComponentModel.DataAnnotations;

namespace ConsoleShopper.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(128)]
        public string FirstName { get; set; }
        [StringLength(128)]
        public string LastName { get; set; }
        [StringLength(128)]
        public string Email { get; set; }
        [StringLength(128)]
        public string PhoneNo { get; set; }

        [StringLength(128)]
        public string Password { get; set; }

        [StringLength(128)]
        public string State { get; set; }
        [StringLength(128)]
        public string  City{ get; set; }
        [StringLength(128)]
        public string  Street { get; set; }
        [StringLength(128)]
        public string  ApartmentNo { get; set; }
        public string  ZipCode { get; set; }

        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public override string ToString()
        {
            return $"Customer Details : \nId: {Id} \nFirst Name: {FirstName} \nLast Name: {LastName}";
        }
    }
}
