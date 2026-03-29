using FluentValidation;


namespace GeoMarker.Application.Features.Markers.Commands.DeleteMarker
{
    public class DeleteMarkerCommandValidator : AbstractValidator<DeleteMarkerCommand>
    {
        public DeleteMarkerCommandValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("Marker ID is required.");
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.");
        }
    }
}
