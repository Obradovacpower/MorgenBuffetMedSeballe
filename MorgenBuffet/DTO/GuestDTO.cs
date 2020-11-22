using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenBuffet.DTO
{
    public class GuestDTO
    {
        public int Id { get; set; }
        public bool IsAdult { get; set; }
        public bool CheckIn { get; set; }
    }
}
