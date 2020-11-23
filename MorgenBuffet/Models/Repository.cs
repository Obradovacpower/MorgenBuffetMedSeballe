using Microsoft.EntityFrameworkCore;
using MorgenBuffet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MorgenBuffet.DTO;

namespace MorgenBuffet.Models
{
    public class Repository
    {
        private ApplicationDbContext db;
        private static Repository repository;

        public Repository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public static Repository GetRepository(ApplicationDbContext db = null)
        {
            if(repository == null)
            {
                repository = new Repository(db);
            }
            return repository;
        }
        private List<OrderDTO> convert(List<OrderEntity> orders)
        {
            List<OrderDTO> ordersDTO = new List<OrderDTO>();
            foreach (OrderEntity order in orders)
            {
                ordersDTO.Add(new OrderDTO(order));
            }
            return ordersDTO;
        }
        //receptionnist
        public async Task AddOrder(OrderDTO newOrder)
        {
            OrderEntity order = new OrderEntity();

            order.Adults = newOrder.Adults;
            order.Kids = newOrder.Kids;
            order.RoomNumber = newOrder.RoomNumber;
            order.Date = DateTime.Today;
            await db.AddAsync(order);
            await db.SaveChangesAsync();

        }
        public async Task<List<OrderDTO>> GetOrdersToday()
        {
            return convert(await db.Set<OrderEntity>().Where(o => o.Date.Date == DateTime.Today && o.CheckIn == true).ToListAsync());
        }
        //restaurant
        public async Task CheckIn(OrderDTO dto)
        {
            OrderEntity order = await db.Set<OrderEntity>().Where(o => o.RoomNumber == dto.RoomNumber && o.Date.Date == DateTime.Today).FirstOrDefaultAsync();
            order.CheckIn = true;
            order.Adults = dto.Adults;
            order.Kids = dto.Kids;
            db.Update(order);
            await db.SaveChangesAsync();
        }
        //kitchen
        public async Task<OrderSumDTO> GetOrders(DateTime date)
        {
            List<OrderEntity> orders = new List<OrderEntity>();
            orders = await db.Set<OrderEntity>().Where(o => o.Date.Date == date.Date).ToListAsync();
            OrderSumDTO sum = new OrderSumDTO();
            foreach(OrderEntity order in orders)
            {
                sum.ExpectedAdults += order.Adults;
                sum.ExpectedKids += order.Kids;
                if (order.CheckIn)
                {
                    sum.Adults += order.Adults;
                    sum.Kids += order.Kids;
                }
                else
                {
                    sum.RemainingAdults += order.Adults;
                    sum.RemainingKids += order.Kids;
                }
            }
            
            return sum;
        }
    }
}
