namespace Recipe_search_program.Models
{
    public class Product
    {
        private bool? enable;

        public int Id { get; set; }

        public string NameProduct { get; set; }
        public bool? Enable
        {
            get => false; set
            {
                Enable = value;
            }
        }
    }
}
