using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;

namespace KhumaloCraft.Web.Service.IService
{
    public interface IBaseService
    {
        Task<ResponseDTO> SendAsync(RequestDTO requestDTO, bool withBearer = true);
    }
}