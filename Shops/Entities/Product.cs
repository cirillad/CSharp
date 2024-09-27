namespace Shops.Entities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        public float Discount { get; set; }
        public int CategoryId { get; set; }
        public Category Category { get; set; }
        public bool IsInStock { get; set; }
    }
}
