using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Dealership_Phone
    {
        [Key]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
        [Key]
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }
    }
}