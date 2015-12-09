using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Automobile
    {
        [Key, Column(Order=0)]
        public string Vin { get; set; }
        [ForeignKey("Dealership"), Column(Order = 1)]
        public int Dealer_id { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public float Mpg { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Body_type { get; set; }
        public int Price { get; set; }
        public bool Damaged_flag { get; set; }

        public virtual Dealership Dealership { get; set; }
    }
}