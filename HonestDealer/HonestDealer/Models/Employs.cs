using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Employs
    {
        [Key][Column(Order = 0)]
        [ForeignKey("Dealership")]
        public int Dealer_id { get; set; }
        public virtual Dealership Dealership { get; set; }
        [Key][Column(Order = 1)]
        [ForeignKey("Salesman")]
        public int Employee_id { get; set; }
        public virtual Salesman Salesman { get; set; }
    }
}