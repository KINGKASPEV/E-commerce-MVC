using System.ComponentModel.DataAnnotations.Schema;

namespace IdentityRoleAuthorization.Models
{
    [Table("Product")]
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public DateTime DatePosted { get; set; }
        public string ImageFileName { get; set; }
    }
}
