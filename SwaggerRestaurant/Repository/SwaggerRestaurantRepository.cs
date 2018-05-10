using SwaggerRestaurant.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace SwaggerRestaurant.Repository
{
    public class SwaggerRestaurantRepository : ISwaggerRestaurantRepository
    {
        private SwaggerRestaurantConnect db = new SwaggerRestaurantConnect();

        public IQueryable<Restaurant> GetRestaurants()
        {
            return db.Restaurants;
        }

        public Restaurant GetRestaurantById(int id)
        {
            Restaurant restaurant = db.Restaurants.Find(id);
            return restaurant;
        }

        public void UpdateRestaurant(Restaurant restaurant)
        {
            db.Entry(restaurant).State = EntityState.Modified;
            db.SaveChanges();
        }

        public Restaurant AddRestaurant(Restaurant restaurant)
        {
            Restaurant newRestaurant = db.Restaurants.Add(restaurant);
            db.SaveChanges();
            return newRestaurant;
        }

        public Restaurant DeleteRestaurant(Restaurant restaurant)
        {
            Restaurant deletedRestaurant =  db.Restaurants.Remove(restaurant);
            db.SaveChanges();
            return deletedRestaurant;
        }

        protected void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
        }

        public bool RestaurantExists(int id)
        {
            return db.Restaurants.Count(e => e.Id == id) > 0;
        }

        public void Dispose()
        {
            db.Dispose();
        }
    }
}