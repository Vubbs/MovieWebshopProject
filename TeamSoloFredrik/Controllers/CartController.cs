using Microsoft.AspNetCore.Mvc;
using TeamSoloFredrik.Extensions;
using TeamSoloFredrik.Models.ViewModels;
using TeamSoloFredrik.Services;

namespace TeamSoloFredrik.Controllers
{
    public class CartController : Controller
    {
        private readonly ICartService _cartService;

        public CartController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult ShoppingCart()
        {
            var cartList = HttpContext.Session.Get<List<int>>("TSFShoppingCart") ?? new List<int>();
            var moviesInCart = _cartService.GetCartItems(cartList);
            return View(moviesInCart);
        }

        // Add item to Session Cart
        [HttpPost]
        public IActionResult AddToCart(int id)
        {
            var cartList = HttpContext.Session.Get<List<int>>("TSFShoppingCart") ?? new List<int>();
            cartList.Add(id);
            var numberOfListItems = cartList.Count();
            HttpContext.Session.Set<List<int>>("TSFShoppingCart", cartList);
            return Json(numberOfListItems);
        }

        // Remove item from Session
        [HttpPost]
        public IActionResult RemoveFromCart(int id)
        {
            var cartList = HttpContext.Session.Get<List<int>>("TSFShoppingCart") ?? new List<int>();
            foreach (var item in cartList)
            {
                if (item == id)
                {
                    cartList.Remove(item);
                    break;
                }
            }
            var numberOfListItems = cartList.Count();
            HttpContext.Session.Set<List<int>>("TSFShoppingCart", cartList);
            return Json(numberOfListItems);
        }
    }
}
