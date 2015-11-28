using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Used_Automobile
    {
        [Key]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        public int Number_of_repairs { get; set; }
        public int Dealer_warranty { get; set; }
        public int Number_of_owners { get; set; }
        public int Mileage { get; set; }
    }
}