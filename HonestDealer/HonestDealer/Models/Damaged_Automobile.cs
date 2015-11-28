using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Damaged_Automobile
    {
        [Key]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        [Key]
        public string Part_name { get; set; }
        [Key]
        public string Location { get; set; }
    }
}