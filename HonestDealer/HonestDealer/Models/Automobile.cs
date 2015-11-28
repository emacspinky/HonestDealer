using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Automobile
    {
        [Key]
        public string Vin { get; set; }
        public int Year { get; set; }
        public string Transmission { get; set; }
        public float Mpg { get; set; }
        public string Make { get; set; }
        public string Model { get; set; }
        public string Body_type { get; set; }
        public int Price { get; set; }
        public bool Damaged_flag { get; set; }
    }
}