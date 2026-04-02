using FluentValidation

namespace GeoMarker.Application.Features.Groups.Queries.GetGroupsByMarkerId
{
    public class GetGroupsByMarkerIdQueryValidator : AbstractValidator<GetGroupsByMarkerIdQuery>
    {
        public GetGroupsByMarkerIdQueryValidator()
        {
            RuleFor(x => x.MarkerId)
                .NotEmpty().WithMessage("Marker ID is required.")
                .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Marker ID must be a valid GUID.");
        }
    }
}
