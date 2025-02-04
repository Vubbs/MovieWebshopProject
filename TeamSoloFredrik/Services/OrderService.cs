using TeamSoloFredrik.Data;
using TeamSoloFredrik.Models.Db;
namespace TeamSoloFredrik.Services
{
    public class OrderService : IOrderService
    {
        private readonly SoloDBContext _db;

        public OrderService(SoloDBContext db)
        {
            _db = db;
        }
        public void CreateOrder(List<int> cartList, int customerId)
        {
            Order newOrder = new Order()
            {
                CustomerID = customerId,
                OrderDate = DateTime.Now
            };
            foreach (int movieId in cartList)
            {
                OrderRow row = new OrderRow()
                {
                    MovieId = movieId,
                    Price = _db.Movies.Where(m => m.Id == movieId).FirstOrDefault().Price
                };
                newOrder.OrderRows.Add(row);
            }
            _db.Orders.Add(newOrder);
            _db.SaveChanges();
        }
    }
}
