/*
Author: Buhle Pikoli
Date: 09/05/2024
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhumaloCraft.Web.Models
{
    public class CouponDTO
    {
        public int CouponID {get; set;}
        public string CouponCode {get; set;}
        public double  DiscountAmount { get; set; }
        public int MinAmount {get; set;}
    }
}