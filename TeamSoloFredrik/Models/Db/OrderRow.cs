using System.ComponentModel.DataAnnotations.Schema;

namespace TeamSoloFredrik.Models.Db
{
    public class OrderRow
    {
        public int Id { get; set; }
        public int OrderId { get; set; }
        public int MovieId { get; set; }
        public decimal Price { get; set; }

        public Order ? Order {  get; set; }
        public Movie ? Movie { get; set; }
    }
}
