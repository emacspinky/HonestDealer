using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Dealership_Phone
    {
        [Key][Column(Order = 0)]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
        public virtual Dealership Dealership { get; set; }
        [Key][Column(Order = 1)]
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }
    }
}