using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace KhumaloCraft.Web.Service.IService
{
    public interface ITokenProvider
    {
        void SetToken(string token);
        string GetToken();
        void ClearToken();
    }
}