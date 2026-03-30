using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Markers.Queries.GetMarkersByUserId
{
    public sealed class GetMarkersByUserIdQueryValidator : AbstractValidator<GetMarkersByUserIdQuery>
    {
        public GetMarkersByUserIdQueryValidator()
        {
            RuleFor(x => x.UserId)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid User ID format.");
        }   
    }
}
