namespace TeamSoloFredrik.Models.Db
{
    public class Customer
    {
        public int Id { get; set; }
        public string Firstname { get; set; } = string.Empty;
        public string Lastname { get; set; } = string.Empty;
        public string BillingAddress { get; set; } = string.Empty;
        public string BillingZip { get; set; } = string.Empty;
        public string BillingCity { get; set; } = string.Empty;
        public string DeliveryAddress { get; set; } = string.Empty;
        public string DeliveryZip { get; set; } = string.Empty;
        public string DeliveryCity { get; set; } = string.Empty;
        public string EmailAddress { get; set; } = string.Empty;
        public string PhoneNo { get; set; } = string.Empty;
        public List<Order> Orders { get; set; } = new List<Order>();
    }
}
