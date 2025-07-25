﻿using AlibabaClone.Application.DTOs.AuthDTOs;
using AlibabaClone.Application.Interfaces;
using AlibabaClone.WebAPI.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace AlibabaClone.WebAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IJwtGenerator _jwtGenerator;

        public AuthController(IAuthService authService, IJwtGenerator jwtGenerator)
        {
            _authService = authService;
            _jwtGenerator = jwtGenerator;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterRequestDto request)
        {
            var result = await _authService.RegisterAsync(request);

            if (!result.IsSuccess || result.Data == null)
            {
                return BadRequest(result.ErrorMessage);
            }

            // generate token and pass it to response
            var token = _jwtGenerator.GenerateToken(result.Data);
            var response = new AuthResponseDto
            {
                PhoneNumber = result.Data.PhoneNumber,
                Roles = result.Data.Roles,
                Token = token
            };

            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequestDto request)
        {
            var result = await _authService.LoginAsync(request);

            if (!result.IsSuccess || result.Data == null)
            {
                return BadRequest(result.ErrorMessage);
            }

            // generate token and pass it to dto
            var token = _jwtGenerator.GenerateToken(result.Data);
            var response = new AuthResponseDto
            {
                PhoneNumber = result.Data.PhoneNumber,
                Roles = result.Data.Roles,
                Token = token
            };

            return Ok(response);
        }
    }
}
