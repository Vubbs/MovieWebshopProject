namespace TeamSoloFredrik.Services
{
    public interface IOrderService
    {
        public void CreateOrder(List<int> cartList, int customerId);
    }
}
