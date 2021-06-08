using System;
using System.Collections.Generic;
using System.Text;

namespace MeijerCodeAssignment.Models
{
    public class StockData
    {
        public string Symbol { get; set; }
        public Profile Profile { get; set; }
        public double Price { get; set; }
        public double Open { get; set; }
        public double High { get; set; }
        public double Low { get; set; }
        public double Volume { get; set; }
    }
}
