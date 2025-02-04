using TeamSoloFredrik.Models.Db;

namespace TeamSoloFredrik.Models.ViewModels
{
    public class SessionMoviesVM
    {
        public List<int> CartList { get; set; }
        public List<Movie> Movies { get; set; }

        public decimal TotalPrice { get; set; }
        public string UserEmail { get; set; }
    }
}
