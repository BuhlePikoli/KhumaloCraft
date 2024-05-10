/*
Author: Buhle Pikoli
Date: 09/05/2024
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using static KhumaloCraft.Web.Utility.StaticDetails;

namespace KhumaloCraft.Web.Models
{
    public class RequestDTO
    {
        public ApiType ApiType {get;  set;} = ApiType.GET;
        public string Url { get; set; }
        public object Data { get; set; }
        public string AccessToken { get; set; }
         public ContentType ContentType { get; set; } = ContentType.Json;
    }
}