using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class New_Automobile
    {
        [Key]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        public int Manuf_warranty { get; set; }
    }
}