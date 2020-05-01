using System.ComponentModel.DataAnnotations;

namespace ConsoleShopper.Domain
{
    public class Customer
    {
        public int Id { get; set; }
        [StringLength(255)]
        public string FirstName { get; set; }
        [StringLength(255)]
        public string LastName { get; set; }

        public string Email { get; set; }
        public string PhoneNo { get; set; }

        [StringLength(16)]
        public string Password { get; set; }

        [StringLength(255)]
        public string Address { get; set; }
        public int UserTypeId { get; set; }
        public virtual UserType UserType { get; set; }

        public override string ToString()
        {
            return $"Customer Details : \nId: {Id} \nFirst Name: {FirstName} \nLast Name: {LastName}";
        }
    }
}
