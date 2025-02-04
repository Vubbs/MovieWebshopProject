namespace TeamSoloFredrik.Models.Db
{
    public class Movie
    {
        public int Id { get; set; }
        public string Title { get; set; } = string.Empty;
        public string Director { get; set; } = string.Empty;
        public int ReleaseYear { get; set; }
        public decimal Price { get; set; }
        public string ImageUrl { get; set; } = string.Empty;
        public List<OrderRow> OrderRows { get; set; } = new List<OrderRow>();
    }
}
