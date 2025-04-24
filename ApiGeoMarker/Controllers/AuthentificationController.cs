using Microsoft.AspNetCore.Http;
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
        public async Task<IActionResult> Register(RegisterRequest request)
        {
            var authResult = await _authentificationService.Register(
                request.FirstName,
                request.LastName,
                request.Email,
                request.Password    
            );

            var response = new AuthentificationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token,
                authResult.User.CreateAt,
                authResult.User.UpdateAt,
                authResult.User.DeleteAt,
                authResult.User.IsActive,
                authResult.User.Role.ToString()
            );
            return Ok(response);
        }

        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginRequest request)
        {
            var authResult = await _authentificationService.Login(
                request.Email,
                request.Password
            );

            var response = new AuthentificationResponse(
                authResult.User.Id,
                authResult.User.FirstName,
                authResult.User.LastName,
                authResult.User.Email,
                authResult.Token,
                authResult.User.CreateAt,
                authResult.User.UpdateAt,
                authResult.User.DeleteAt,
                authResult.User.IsActive,
                authResult.User.Role.ToString()
            );
            return Ok(response);
        }

    }


}
