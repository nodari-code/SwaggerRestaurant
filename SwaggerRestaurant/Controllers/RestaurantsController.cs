using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Web.Http;
using System.Web.Http.Description;
using SwaggerRestaurant.Models;
using SwaggerRestaurant.Repository;

namespace SwaggerRestaurant.Controllers
{
    public class RestaurantsController : ApiController
    {
        private ISwaggerRestaurantRepository swaggerRestaurantRepository;

        //public RestaurantsController() : base(){ }
        public RestaurantsController()  { }
        public RestaurantsController(ISwaggerRestaurantRepository swaggerRestaurantRepository) //:this()
        {
            this.swaggerRestaurantRepository = swaggerRestaurantRepository;
        }

        // GET: api/Restaurants
        /// <summary>
        /// Get list of all restaurants
        /// </summary>
        /// <returns>List of restaurants</returns>
        public IQueryable<Restaurant> GetRestaurants()
        {
            return swaggerRestaurantRepository.GetRestaurants();
        }

        // GET: api/Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult GetRestaurant(int id)
        {
            Restaurant restaurant = swaggerRestaurantRepository.GetRestaurantById(id);
            if (restaurant == null)
            {
                return NotFound();
            }

            return Ok(restaurant);
        }

        // PUT: api/Restaurants/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutRestaurant(int id, Restaurant restaurant)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);
            if (id != restaurant.Id) return BadRequest();

            try
            {
                swaggerRestaurantRepository.UpdateRestaurant(restaurant);
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!swaggerRestaurantRepository.RestaurantExists(id))
                {
                    return NotFound();
                }
                else
                {
                    //throw;
                    return StatusCode(HttpStatusCode.InternalServerError);
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/Restaurants
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult PostRestaurant(Restaurant restaurant)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            Restaurant newRestaurant =  swaggerRestaurantRepository.AddRestaurant(restaurant);

            return CreatedAtRoute("DefaultApi", new { id = newRestaurant.Id }, newRestaurant);
        }

        // DELETE: api/Restaurants/5
        [ResponseType(typeof(Restaurant))]
        public IHttpActionResult DeleteRestaurant(int id)
        {
            Restaurant restaurant = swaggerRestaurantRepository.GetRestaurantById(id);
            if (restaurant == null) return NotFound();
            Restaurant deletedRestaurant = swaggerRestaurantRepository.DeleteRestaurant(restaurant);
            return Ok(deletedRestaurant);
        }
    }
}