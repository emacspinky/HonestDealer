using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class Salesman
    {
        [Key]
        public int Employee_id { get; set; }
        public string Name { get; set; }
        public float Rating { get; set; }
        public int Salary { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string Phone_number { get; set; }
        public int Available_appts { get; set; }
        public bool Used_flag { get; set; }
        public bool New_flag { get; set; }
    }
}