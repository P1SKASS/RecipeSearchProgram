namespace Recipe_search_program.Models
{
    public class Product
    {
        public int Id { get; set; }

        public required string NameProduct { get; set; }
        public bool? Enable { get; set; }
    }
}
