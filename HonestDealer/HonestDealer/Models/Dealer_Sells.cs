using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Dealer_Sells
    {
        [Key]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
        [Key]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
    }
}