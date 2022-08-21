using System.ComponentModel.DataAnnotations;

namespace myWebAppTest.Models.Entities
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        public string Description { get; set; }
        public int Price { get; set; }
    }
}
