using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Contracts
    {
        [Key][Column(Order = 0)]
        [ForeignKey("Mechanic")]
        public string Mech_name { get; set; }
        public virtual Mechanic Mechanic { get; set; }
        [Key][Column(Order = 1)]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
        public virtual Dealership Dealership { get; set; }
    }
}