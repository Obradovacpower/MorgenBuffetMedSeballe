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
        public void AddOrder(OrderDTO newOrder)
        {
            OrderEntity order = new OrderEntity();

            order.Adults = newOrder.Adults;
            order.Kids = newOrder.Kids;
            order.RoomNumber = newOrder.RoomNumber;
            order.Date = DateTime.Today;
            db.Add(order);
            db.SaveChanges();

        }
        public List<OrderEntity> GetOrdersToday()
        {
            return db.Set<OrderEntity>().Where(o => o.Date == DateTime.Today && o.CheckIn == true).ToList();
        }
        //restaurant
        public void CheckIn(OrderDTO DTO)
        {
            OrderEntity order = db.Set<OrderEntity>().Where(o => o.RoomNumber == DTO.RoomNumber && o.Date.Date == DateTime.Today).FirstOrDefault();
            order.CheckIn = true;
            order.Adults = DTO.Adults;
            order.Kids = DTO.Kids;
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
