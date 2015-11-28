using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Dealer_Sells
    {
        [Key][Column(Order = 0)]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
        public virtual Dealership Dealership { get; set; }
        [Key][Column(Order = 1)]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        public virtual Automobile Automobile { get; set; }
    }
}