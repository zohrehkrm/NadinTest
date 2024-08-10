namespace NadinTest.Models.Products
{
    public class ProductSelectDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
