using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Mechanic
    {
        [Key]
        public string Name { get; set; }
        public float Rating { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }
        public int Salary { get; set; }
    }
}