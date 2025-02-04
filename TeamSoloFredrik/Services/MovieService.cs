using Microsoft.AspNetCore.Mvc;

using TeamSoloFredrik.Data;
using TeamSoloFredrik.Models.Db;
using TeamSoloFredrik.Models.ViewModels;

namespace TeamSoloFredrik.Services
{
    public class MovieService : IMovieService
    {
        private readonly SoloDBContext _db;
        
        public MovieService(SoloDBContext db) 
        {
            _db = db;
        }

        public void AddMovie(Movie movie)
        {
            _db.Movies.Add(movie);
            _db.SaveChanges();
        }

        public List<Movie> GetMovies()
        {
            var movieList = _db.Movies.ToList();
            return movieList;
        }

        public CustomerMovieOrdersVM GetAllData()
        {
            CustomerMovieOrdersVM frontPageData = new CustomerMovieOrdersVM();
            var movies = _db.Movies.ToList();
            var customers = _db.Customers.ToList();
            var orders = _db.Orders.ToList();
            var orderRows = _db.OrderRows.ToList();
            frontPageData.Orders = orders;
            frontPageData.OrderRows = orderRows;
            frontPageData.Customers = customers;
            frontPageData.Movies = movies;

            return frontPageData;
        }
    }
}
