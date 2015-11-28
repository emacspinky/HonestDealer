using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Previous_Owner
    {
        [Key]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        [Key]
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }
        public string Name { get; set; }
    }
}