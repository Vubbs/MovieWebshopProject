using TeamSoloFredrik.Models.ViewModels;

namespace TeamSoloFredrik.Services
{
    public interface ICustomerService
    {
        public OrderOrderRowsVM GetCustomerOrders(string email);
    }
}
