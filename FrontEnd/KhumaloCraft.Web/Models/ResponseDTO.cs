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
    public class ResponseDTO
    {
        public object Result { get; set; }
        public bool isSuccess {get; set; } = true;
        public string Message { get; set; } = "";
    }
}