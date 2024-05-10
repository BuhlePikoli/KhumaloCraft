/*
Author: Buhle Pikoli
Date: 09/05/2024
*/

namespace KhumaloCraft.Web.Models
{
    public class CartDto
    {
        public CartHeaderDto CartHeader { get; set; }
        public IEnumerable<CartDetailsDto> CartDetails { get; set; }
    }
}
