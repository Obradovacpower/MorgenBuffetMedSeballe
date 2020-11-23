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

        private Repository(ApplicationDbContext db)
        {
            this.db = db;
        }
        public static void AddRepository(ApplicationDbContext db)
        {
            repository = new Repository(db);
        }
        public static Repository GetRepository()
        {
            return repository;
        }
        //receptionnist
        public async Task AddOrder(OrderDTO newOrder)
        {
            OrderEntity order = new OrderEntity();

            order.Adults = newOrder.Adults;
            order.Kids = newOrder.Kids;
            order.RoomNumber = newOrder.RoomNumber;
            order.Date = DateTime.Today;
            db.Add(order);
            await db.SaveChangesAsync();

        }
        public async Task<List<OrderEntity>> GetOrdersToday()
        {
            return await db.Set<OrderEntity>().Where(o => o.Date == DateTime.Today && o.CheckIn == true).ToListAsync();
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
        public async Task<List<OrderEntity>> GetOrders(DateTime date)
        {
            return await db.Set<OrderEntity>().Where(o => o.Date.Date == date.Date).ToListAsync();
        }
    }
}
