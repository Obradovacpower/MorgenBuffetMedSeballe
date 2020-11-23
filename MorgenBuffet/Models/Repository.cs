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
        public async Task<IAsyncResult> AddOrder(OrderDTO newOrder)
        {
            OrderEntity order = new OrderEntity();

            order.Adults = newOrder.Adults;
            order.Kids = newOrder.Kids;
            order.RoomNumber = newOrder.RoomNumber;
            order.Date = DateTime.Today;
            db.Add(order);
            await db.SaveChangesAsync();
            return Ok(order);

        }
        public List<OrderEntity> GetOrdersToday()
        {
            return db.Set<OrderEntity>().Where(o => o.Date == DateTime.Today && o.CheckIn == true).ToList();
        }
        //restaurant
        public void CheckIn(int roomNumber, int adults, int kids)
        {
            OrderEntity order = db.Set<OrderEntity>().Where(o => o.RoomNumber == roomNumber && o.Date.Date == DateTime.Today).FirstOrDefault();
            order.CheckIn = true;
            order.Adults = adults;
            order.Kids = kids;
            db.Update(order);
            db.SaveChanges();
        }
        //kitchen
        public List<OrderEntity> GetOrders(DateTime date)
        {
            return db.Set<OrderEntity>().Where(o => o.Date.Date == date.Date).ToList();
        }
    }
}
