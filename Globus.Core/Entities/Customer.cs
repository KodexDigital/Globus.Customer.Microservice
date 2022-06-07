namespace Globus.Core.Entities
{
    public class Customer
    {
        public int CustomerId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StateOfResidence { get; set; }
        public string LGA { get; set; }
        public DateTime DateCreated { get; set; }

        public Customer()
        {
            DateCreated = DateTime.Now;
        }
    }
}
