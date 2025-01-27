using MediatR;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GeoMarker.Application.Common.Eceptions;

namespace GeoMarker.Application.Common.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator) 
        {
            _validators = validator;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);

            var errors = _validators
                .Select(x => x.Validate(context))       // Exécute chaque validateur
                .SelectMany(x => x.Errors)              // Récupère toutes les erreurs
                .Where(x => x != null)                  // Filtre les erreurs non nulles
                .Select(x => x.ErrorMessage)            // Extrait les messages d'erreur
                .Distinct()                             // Élimine les doublons
                .ToArray();                             // Convertit en tableau

            if (errors.Any())
                throw new BadRequestException(errors);

            return await next();
        }
    }
}
