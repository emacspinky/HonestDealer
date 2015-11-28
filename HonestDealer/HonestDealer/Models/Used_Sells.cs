using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Used_Sells
    {
        [Key]
        [ForeignKey("Salesman")]
        public int Employee_id { get; set; }
        [Key]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
    }
}