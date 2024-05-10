/*
Author: Buhle Pikoli
Date: 09/05/2024
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KhumaloCraft.Web.Models;

namespace KhumaloCraft.Web.Service.IService
{
    public interface IAuthService
    {
        Task<ResponseDTO> LoginAsync(LoginRequestDTO loginRequestDTO);
        Task<ResponseDTO> RegisterAsync(RegistrationRequestDTO registrationRequestDTO);
        Task<ResponseDTO> AssignRoleAsync(RegistrationRequestDTO registrationRequestDTO);
    }
}