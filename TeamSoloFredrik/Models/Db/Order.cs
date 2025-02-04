namespace TeamSoloFredrik.Models.Db
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime OrderDate { get; set; }
        public int CustomerID { get; set; }
        public Customer ? Customer { get; set; }
        public List<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
    }
}
