using Microsoft.AspNetCore.Mvc;
using TeamSoloFredrik.Models.ViewModels;
using TeamSoloFredrik.Extensions;
using TeamSoloFredrik.Models.Db;
using TeamSoloFredrik.Data;

namespace TeamSoloFredrik.Services
{
    public class CartService : ICartService
    {
        private readonly SoloDBContext _db;

        public CartService(SoloDBContext db)
        {
            _db = db;
        }

        public List<int> GetOrder()
        {
            var cartList = new List<int>();
            return cartList;
        }


        // Get cartList and put the movies in the cartList to the ViewModel, removing duplicates
        public SessionMoviesVM GetCartItems(List<int> cartList)
        {
            SessionMoviesVM sessionMoviesVM = new SessionMoviesVM();
            List<Movie> moviesInCart = new List<Movie>();
            foreach (var item in cartList)
            {
                foreach (var movie in _db.Movies)
                {
                    if (movie.Id == item)
                    {
                        if (!moviesInCart.Contains(movie)) // for removing duplicate entries of the same movie
                        {
                            moviesInCart.Add(movie);
                        }
                        sessionMoviesVM.TotalPrice += movie.Price;
                    }
                }
            }
            sessionMoviesVM.Movies = moviesInCart;
            sessionMoviesVM.CartList = cartList;

            return sessionMoviesVM;
        }
    }
}
