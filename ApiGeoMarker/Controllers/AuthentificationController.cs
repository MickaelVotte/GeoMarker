﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using GeoMarker.Contracts.Authentification;
using GeoMarker.Application.Services.Authentification;


namespace GeoMarker.Api.Controllers
{

    [Route("auth")]
    [ApiController]
    public class AuthentificationController : ControllerBase
    {

        private readonly IAuthentificationService _authentificationService;

        public AuthentificationController(IAuthentificationService authentificationService)
        {
            _authentificationService = authentificationService;
        }



            [HttpPost("register")]
        public IActionResult Register(RegisterRequest request)
        {
            var authResult = _authentificationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password
            );

            var response = new AuthentificationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token
            );
            return Ok(response);
        }

        [HttpPost("login")]
        public IActionResult Login(LoginRequest request)
        {
            var authResult = _authentificationService.Login(
                request.Email,
                request.Password
            );

            var response = new AuthentificationResponse(
                authResult.Id,
                authResult.FirstName,
                authResult.LastName,
                authResult.Email,
                authResult.Token
            );
            return Ok(response);
        }

    }


}
