using TeamSoloFredrik.Models.Db;

namespace TeamSoloFredrik.Models.ViewModels
{
    public class CustomerMovieOrdersVM
    {
        public List<Customer> Customers { get; set; } = new List<Customer>();
        public List<Movie> Movies { get; set; } = new List<Movie>();
        public List<Order> Orders { get; set; } = new List<Order>();
        public List<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
    }
}
