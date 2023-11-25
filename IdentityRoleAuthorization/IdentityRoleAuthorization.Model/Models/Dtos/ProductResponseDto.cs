using System.ComponentModel.DataAnnotations;

namespace IdentityRoleAuthorization.Models.Dtos
{
    public class ProductResponseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)] 
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public string ImageFileName { get; set; }
        public DateTime ManufacturingDate { get; set; } = DateTime.Now;

        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)]
        public decimal TotalValue => Price * InStock;

    }
}
