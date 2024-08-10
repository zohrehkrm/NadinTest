using System.ComponentModel.DataAnnotations;

namespace NadinTest.Models.Products
{
    public class ProductDto
    {
        public Guid Id { get; set; }

        [Required(ErrorMessage = "نام کالا ضروری است.") ]
        public string Name { get; set; }
        public DateTime ProduceDate { get; set; }
        public string ManufacturePhone { get; set; }
        public string ManufactureEmail { get; set; }
        public bool IsAvailable { get; set; }
    }
}
