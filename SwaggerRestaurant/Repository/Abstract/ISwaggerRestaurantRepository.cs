using System.Linq;
using SwaggerRestaurant.Models;
using System;

namespace SwaggerRestaurant.Repository
{
    public interface ISwaggerRestaurantRepository : IDisposable
    {
        IQueryable<Restaurant> GetRestaurants();

        Restaurant GetRestaurantById(int id);

        void UpdateRestaurant(Restaurant restaurant);

        Restaurant AddRestaurant(Restaurant restaurant);

        Restaurant DeleteRestaurant(Restaurant restaurant);

        bool RestaurantExists(int id);
    }
}
