using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace CouponAPI.Models
{
    public class Coupon
    {
        [Key]
        public int CouponID {get; set;}
        [Required]
        public string CouponCode {get; set;}
        [Required]
        public double  DiscountAmount { get; set; }
        public int MinAmount {get; set;}
    }
}