using MediatR;
using FluentValidation;

namespace GeoMarker.Application.Common.Behaviors
{
    public sealed class ValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
    {

        private readonly IEnumerable<IValidator<TRequest>> _validators;
        public ValidationBehavior(IEnumerable<IValidator<TRequest>> validator)
        {
            _validators = validator;
        }

        public async Task<TResponse> Handle(
            TRequest request,
            RequestHandlerDelegate<TResponse> next,
            CancellationToken cancellationToken)
        {
            if (!_validators.Any())
            {
                return await next();
            }

            var context = new ValidationContext<TRequest>(request);
            var validationResults = await Task.WhenAll(
                _validators.Select(v => v.ValidateAsync(context, cancellationToken))
            );

            var errors = validationResults              // Exécute chaque validateur
                .SelectMany(x => x.Errors)              // Récupère toutes les erreurs
                .Where(x => x != null)                  // Filtre les erreurs non nulles
                .ToList();                            

            if (errors.Any())
                throw new ValidationException(errors);

            return await next();
        }
    }
}
