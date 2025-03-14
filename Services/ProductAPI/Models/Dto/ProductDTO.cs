using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models.Dto
{
    public class ProductDTO
    {
        [Key]
        public int ProductId { get; set; }
        [Required]
        public string Name { get; set; }
        public double Price { get; set; }
        public string CategoryName { get; set; }
        public string Description { get; set; }
        public string ImageUrl { get; set; }
        public string ImageLocalPath { get; set; }
        public IFormFile Image { get; set; }
    }
}