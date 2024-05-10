using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductAPI.Models.Dto
{
    public class ResponseDTO
    {
        public object Result { get; set; }
        public bool isSuccess {get; set; } = true;
        public string Message { get; set; } = "";
    }
}