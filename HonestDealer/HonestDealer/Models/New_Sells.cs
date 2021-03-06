﻿using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.ComponentModel.DataAnnotations.Schema;

namespace HonestDealer.Models
{
    public class New_Sells
    {
        [Key][Column(Order = 0)]
        [ForeignKey("Salesman")]
        public int Employee_id { get; set; }
        public virtual Salesman Salesman { get; set; }
        [Key][Column(Order = 1)]
        [ForeignKey("Automobile")]
        public string Vin { get; set; }
        public virtual Automobile Automobile { get; set; }
    }
}