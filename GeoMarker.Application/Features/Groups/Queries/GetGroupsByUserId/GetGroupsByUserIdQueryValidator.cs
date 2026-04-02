using FluentValidation;

namespace GeoMarker.Application.Features.Groups.Queries.GetGroupsByUserId
{
    public class GetGroupsByUserIdQueryValidator : AbstractValidator<GetGroupsByUserIdQuery>
    {
        public GetGroupsByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("User ID must be a valid GUID.");
        }
    }
}
