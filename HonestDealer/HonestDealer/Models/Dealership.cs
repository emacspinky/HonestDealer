using System.ComponentModel.DataAnnotations;
using System.Globalization;

namespace HonestDealer.Models
{
    public class Dealership
    {
        [Key]
        public int Dealer_id { get; set; }
        public string Name { get; set; }
        [DataType(DataType.Url)]
        public string Web_address { get; set; }
        public string Makes_sold { get; set; }
        public float Dealer_rating { get; set; }
        public int Car_count { get; set; }
        public string Username { get; set; }
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DataType(DataType.DateTime)]
        public string Open_time { get; set; }
        [DataType(DataType.DateTime)]
        public string Close_time { get; set; }
    }
}