using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Exterior_Color
    {
        [Key]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        [Key]
        public string Color { get; set; }
    }
}