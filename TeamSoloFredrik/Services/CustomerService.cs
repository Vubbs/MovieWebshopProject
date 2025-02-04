using TeamSoloFredrik.Data;
using TeamSoloFredrik.Models.ViewModels;

namespace TeamSoloFredrik.Services
{
    public class CustomerService : ICustomerService
    {
        private readonly SoloDBContext _db;
        public CustomerService(SoloDBContext db)
        {
            _db = db;
        }
        public OrderOrderRowsVM GetCustomerOrders(string email)
        {
            OrderOrderRowsVM getCustomerOrders = new OrderOrderRowsVM();
            foreach (var item in _db.Customers)
            {
                if (item.EmailAddress == email)
                {
                    getCustomerOrders.CustomerID = item.Id;
                }
            }
            foreach (var item in _db.Orders)
            {
                if (item.CustomerID == getCustomerOrders.CustomerID)
                {
                    getCustomerOrders.Orders.Add(item);
                }
            }
            foreach (var item in _db.OrderRows)
            {
                foreach (var order in getCustomerOrders.Orders)
                {
                    if (item.OrderId == order.Id)
                    {
                        getCustomerOrders.OrderRows.Add(item);
                    }
                }
            }
            foreach (var item in _db.Movies)
            {
                foreach (var row in getCustomerOrders.OrderRows)
                {
                    if (item.Id == row.MovieId)
                    {
                        getCustomerOrders.Movies.Add(item);
                    }
                }
            }
            return getCustomerOrders;
        }
    }
}
