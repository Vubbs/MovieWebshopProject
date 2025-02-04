using TeamSoloFredrik.Models.ViewModels;

namespace TeamSoloFredrik.Services
{
    public interface ICartService
    {
        public List<int> GetOrder();
        public SessionMoviesVM GetCartItems(List<int> cartList);
    }
}
