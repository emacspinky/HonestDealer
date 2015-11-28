using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Previous_Owner
    {
        [Key][Column(Order = 0)]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        public virtual Automobile Automobile { get; set; }
        [Key][Column(Order = 1)]
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }
        public string Name { get; set; }
    }
}