using FluentValidation;


namespace GeoMarker.Application.Features.Markers.Queries.SearchMarkers
{
    public sealed class SearchMarkersQueryValidator : AbstractValidator<SearchMarkersQuery>
    {
        public SearchMarkersQueryValidator()
        {
            RuleFor(x => x.Title)
                .MaximumLength(100).WithMessage("Title cannot exceed 100 characters.");
            RuleFor(x => x.Description)
                .MaximumLength(500).WithMessage("Description cannot exceed 500 characters.");
        }
    }
}
