﻿namespace IdentityRoleAuthorization.Models.Dtos
{
    public class ProductResponseDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int InStock { get; set; }
        public DateTime ManufacturingDate { get; set; }
        public decimal TotalValue { get; set; } 

        //public decimal TotalValue { get; }

    }
}
