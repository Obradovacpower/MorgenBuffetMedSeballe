using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenBuffet.Models
{
    public class OrderEntity
    {
        public int Id { get; set; }
        public bool CheckIn { get; set; }
        public int RoomNumber { get; set; }
        public DateTime Date { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }
    }
}
