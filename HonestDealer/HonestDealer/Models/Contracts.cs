using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Contracts
    {
        [Key]
        [ForeignKey("Mechanic")]
        public string Mech_name { get; set; }
        [Key]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
    }
}