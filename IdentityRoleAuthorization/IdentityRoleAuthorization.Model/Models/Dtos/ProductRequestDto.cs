﻿using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace IdentityRoleAuthorization.Models.Dtos
{
    public class ProductRequestDto
    {
        [Required(ErrorMessage = "Name is required.")]
        public string Name { get; set; }

        [MaxLength(5000, ErrorMessage = "Description cannot exceed 5000 characters.")]
        public string Description { get; set; }

        [Range(0, double.MaxValue, ErrorMessage = "Price must be a non-negative value.")]
        [DisplayFormat(DataFormatString = "{0:C}", ApplyFormatInEditMode = true)] 
        public decimal Price { get; set; }

        [Display(Name = "In Stock")]
        [Range(0, int.MaxValue, ErrorMessage = "In stock quantity must be a non-negative integer.")]
        public int InStock { get; set; }

        [Display(Name = "Manufacturing Date")]
        [DataType(DataType.Date)]
        public DateTime DatePosted { get; set; } = DateTime.Now;

        [Display(Name = "Product Image")]
        public IFormFile ImageFile { get; set; }
    }
}



