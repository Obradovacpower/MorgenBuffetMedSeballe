using Microsoft.EntityFrameworkCore;
using MorgenBuffet.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MorgenBuffet.Models;
using MorgenBuffet.DTO;

namespace MorgenBuffet.Repository
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
        public Repository GetRepository()
        {
            return repository;
        }
        //receptionnist
        public void AddOrder(int roomNumber, int adults, int kids)
        {
            OrderEntity order = new OrderEntity();

            order.Adults = adults;
            order.Kids = kids;
            order.RoomNumber = roomNumber;
            order.Date = DateTime.Today;
            db.Add(order);
            db.SaveChanges();

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
