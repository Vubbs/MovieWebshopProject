using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;
using TeamSoloFredrik.Data;
using TeamSoloFredrik.Extensions;
using TeamSoloFredrik.Models.Db;
using TeamSoloFredrik.Models.ViewModels;
using TeamSoloFredrik.Services;

namespace TeamSoloFredrik.Controllers
{
    public class CustomerController : Controller
    {
        private readonly SoloDBContext _db;
        private readonly ICustomerService _customerService;
        private readonly IMovieService _movieService;

        public CustomerController(SoloDBContext db,ICustomerService customerService,IMovieService movieService)
        {
            _db = db;
            _customerService = customerService;
            _movieService = movieService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Create(Customer customer)
        {
            if(ModelState.IsValid && customer != null)
            {
                _db.Customers.Add(customer);
                _db.SaveChanges();
                ViewBag.Customer = "Customer Added Successfully!";
            }
            else
            {
                ViewBag.Customer = "Something went wrong, please look over the form and add";
            }
            return View();
        }

        [Route("/Customer/Order")]
        public IActionResult Orders(string email)
        {
            foreach (var customer in _db.Customers)
            {
                if (email == customer.EmailAddress && email != null)
                {
                    ViewBag.OrderListSuccess = $"Here are all orders for {customer.Firstname} {customer.Lastname}";
                    var orderList = _customerService.GetCustomerOrders(email);
                    
                    return View(orderList);
                }
                if (email == null)
                {
                    return View();
                }
            }
            ViewBag.OrderListFail = $"Cannot find any orders under the e-mail address '{email}'.";
            return View();
        }


        public IActionResult AllOrders()
        {
            CustomerMovieOrdersVM allOrders = _movieService.GetAllData();
            return View(allOrders);
        }
    }
}
