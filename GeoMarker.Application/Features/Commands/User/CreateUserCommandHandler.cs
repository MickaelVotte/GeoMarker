using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMarker.Domain.Entities;
using GeoMarker.Domain.Interfaces;

namespace GeoMarker.Application.Features.Commands.User
{
    class CreateUserCommandHandler : IRequestHandler<CreateUserCommand, Guid>
    {
        private readonly IUserRepository _userRepository;
        private readonly IPasswordHasher _passwordHasher;

        public CreateUserCommandHandler(IUserRepository userRepository, IPasswordHasher passwordHasher)
        {
            _userRepository = userRepository;
            _passwordHasher = passwordHasher;
        }

        public async Task<Guid> Handle(CreateUserCommand command, CancellationToken cancellationToken)
        {
            // Hashage du mot de passe
            var passwordHash = _passwordHasher.HashPassword(command.Password);

            // Création de l'entité User
            var user = new User(command.FirstName, command.LastName, command.Email, passwordHash);

            // Persistance de l'utilisateur dans la base de données
            await _userRepository.CreateAsync(user);

            return user.Id;
        }
    }
}