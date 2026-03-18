using FluentValidation;


namespace GeoMarker.Application.Features.Users.Commands.DesactiveUser
{
    public class DesactiveUserCommandValidator : AbstractValidator<DesactiveUserCommand>
    {
        public DesactiveUserCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
