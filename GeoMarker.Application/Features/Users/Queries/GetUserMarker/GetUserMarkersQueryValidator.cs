using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Users.Queries.GetUserMarker
{
    public class GetUserMarkersQueryValidator : AbstractValidator<GetUserMarkersQuery>
    {
        public GetUserMarkersQueryValidator()
        {
            RuleFor(x => x.Id)
                .NotEmpty().WithMessage("User ID is required.")
                .Must(id => Guid.TryParse(id.ToString(), out _)).WithMessage("Invalid User ID format.");
        }
    }
}
