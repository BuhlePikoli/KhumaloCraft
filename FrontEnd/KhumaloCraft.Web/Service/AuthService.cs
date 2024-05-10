using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;
using KhumaloCraft.Web.Service.IService;
using KhumaloCraft.Web.Utility;

namespace KhumaloCraft.Web.Service
{
    public class AuthService : IAuthService
    {
        private readonly IBaseService _baseService;
        public AuthService(IBaseService baseService)
        {
            _baseService = baseService;
        }
        public async Task<ResponseDTO> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType = StaticDetails.ApiType.POST,
                Data=registrationRequestDTO,
                Url = StaticDetails.AuthAPIBase+"/api/auth/assignRole"
            });
        }

        public async Task<ResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType = StaticDetails.ApiType.POST,
                Data=loginRequestDTO,
                Url = StaticDetails.AuthAPIBase+"/api/auth/login"
            }, withBearer: false);
        }

        public async Task<ResponseDTO> RegisterAsync(RegistrationRequestDTO registrationRequestDTO)
        {
            return await _baseService.SendAsync(new RequestDTO{
                ApiType = StaticDetails.ApiType.POST,
                Data=registrationRequestDTO,
                Url = StaticDetails.AuthAPIBase+"/api/auth/register"
            }, withBearer: false);
        }
    }
}