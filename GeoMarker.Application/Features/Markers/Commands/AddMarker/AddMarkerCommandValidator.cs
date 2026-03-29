using GeoMarker.Application.Interfaces;
using FluentValidation;

namespace GeoMarker.Application.Features.Markers.Commands.AddMarker
{
    public class AddMarkerCommandValidator : AbstractValidator<AddMarkerCommand>
    {
        public AddMarkerCommandValidator(IMarkerRepository markerRepository)
        {
            RuleFor(x => x.Title)
                .NotEmpty().WithMessage("Title is required.")
                .MaximumLength(100).WithMessage("Title must not exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description must not exceed 500 characters.");
            RuleFor(x => x.Latitude)
                .InclusiveBetween(-90, 90).WithMessage("Latitude must be between -90 and 90.");
            RuleFor(x => x.Longitude)
                .InclusiveBetween(-180, 180).WithMessage("Longitude must be between -180 and 180.");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
