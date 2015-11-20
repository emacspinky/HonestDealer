using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HonestDealer.Models
{
    public class Contact
    {
        [Key]
        public int ContactId { get; set; } // Primary key that is needed by the database
        public string Name { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string Zip { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
    }
}