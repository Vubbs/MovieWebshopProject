using TeamSoloFredrik.Models.Db;

namespace TeamSoloFredrik.Models.ViewModels
{
    public class OrderOrderRowsVM
    {
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public int CustomerID { get; set; }
    }
}
