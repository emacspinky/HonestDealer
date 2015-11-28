using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Interior_Color
    {
        [Key][Column(Order = 0)]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        public virtual Automobile Automobile { get; set; }
        [Key][Column(Order = 1)]
        public string Color { get; set; }
    }
}