﻿/*
Author: Buhle Pikoli
Date: 09/05/2024
*/

namespace KhumaloCraft.Web.Models
{
    public class CartDetailsDto
    {
        public int CartDetailsId { get; set; }
        public int CartHeaderId { get; set; }
        public CartHeaderDto CartHeader { get; set; }
        public int ProductId { get; set; }
        public ProductDTO Product { get; set; }
        public int Count { get; set; }
    }
}
