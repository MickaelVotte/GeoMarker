using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMarker.Application.Services.Authentification;
using MediatR;

namespace GeoMarker.Application.Features.Commands.User.LoginUpdate
{
    public sealed class LoginUserCommand : IRequest<AuthentificationResult>
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public LoginUserCommand(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
   
}
