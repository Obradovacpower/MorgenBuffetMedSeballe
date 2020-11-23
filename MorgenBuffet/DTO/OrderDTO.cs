using MorgenBuffet.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MorgenBuffet.DTO
{
    public class OrderDTO
    {
        public OrderDTO() { }
        public OrderDTO(OrderEntity order)
        {
            RoomNumber = order.RoomNumber;
            Adults = order.Adults;
            Kids = order.Kids;
        }

        public int RoomNumber { get; set; }
        public int Adults { get; set; }
        public int Kids { get; set; }

    }
}
