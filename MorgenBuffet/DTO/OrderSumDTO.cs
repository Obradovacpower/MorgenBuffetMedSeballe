using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenBuffet.DTO
{
    public class OrderSumDTO
    {
        public int ExpectedAdults { get; set; }
        public int ExpectedKids { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }
        public int RemainingAdults { get; set; }
        public int RemainingKids { get; set; }
    }
}
