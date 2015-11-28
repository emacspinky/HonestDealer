using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Employs
    {
        [Key]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
        [Key]
        [ForeignKey("Salesman")]
        public int Employee_id { get; set; }
    }
}