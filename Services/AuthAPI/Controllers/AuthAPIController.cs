using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AuthAPI.Data;
using AuthAPI.Models.Dto;
using AuthAPI.Services.IServices;
using Microsoft.AspNetCore.Mvc;

namespace AuthAPI.Controllers
{
    [ApiController]
    [Route("api/auth")]
    public class AuthAPIController : ControllerBase
    {
        private readonly IAuthService _authService;
        private ResponseDTO _response;

        public AuthAPIController(IAuthService authService)
        {
            _authService = authService;
            _response = new();
        }
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegistrationRequestDTO model){
            var errorMessage = await _authService.Register(model);
            if (!string.IsNullOrEmpty(errorMessage)){
                _response.isSuccess = false;
                _response.Message = errorMessage;
                return BadRequest(_response);
            }
            return Ok(_response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] LoginRequestDTO model){
            var loginResponse = await _authService.Login(model);
            if (loginResponse.User == null){
                _response.isSuccess = false;
                _response.Message = "Invalid username or password.";
                return Unauthorized(_response);
            }
            _response.Result = loginResponse;
            return Ok(_response);
        }

        [HttpPost("assignRole")]
        public async Task<IActionResult> AssignRole([FromBody] RegistrationRequestDTO model){
            var assignRoleSuccessful = await _authService.AssignRole(model.Email, model.Role.ToUpper());
            if (!assignRoleSuccessful){
                _response.isSuccess = false;
                _response.Message = "Error encountered while assigning role to user " + model.Email;
                return BadRequest(_response);
            }
            return Ok(_response);
        }
    }
}