using Microsoft.AspNetCore.Mvc;
using TeamSoloFredrik.Data;
using TeamSoloFredrik.Extensions;
using TeamSoloFredrik.Services;

namespace TeamSoloFredrik.Controllers
{
    public class OrderController : Controller
    {
        private readonly SoloDBContext _db;
        private readonly IOrderService _orderService;
        private readonly ICartService _cartService;
        
        public OrderController(SoloDBContext db,IOrderService orderService,ICartService cartService)
        {
            _db = db;
            _orderService = orderService;
            _cartService = cartService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult MakeOrder(string email)
        {
            var cartList = HttpContext.Session.Get<List<int>>("TSFShoppingCart") ?? new List<int>();
            var customerId = 0;
            foreach (var customer in _db.Customers)
            {
                if (customer.EmailAddress == email)
                    customerId = customer.Id;

            }
            if (customerId == 0)
            {
                TempData["CNotFound"] = "You need to add yourself as a Customer before you can place an Order.";
                return RedirectToAction("Create", "Customer");
            }

            _orderService.CreateOrder(cartList, customerId);
            var sessionVM = _cartService.GetCartItems(cartList);
            return View(sessionVM);
        }
    }
}
