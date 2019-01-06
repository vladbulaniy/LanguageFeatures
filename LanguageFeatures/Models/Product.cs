namespace LanguageFeatures.Models
{
    public class Product
    {
        private string name;
        public string Name
        {
            get { return name; }
            set { name = value; }
        }
        public decimal Price { get; set; }
        public string Category { get; set; }
        public int ProductId { get; set; }
        public string Description { get; set; }
    }
}