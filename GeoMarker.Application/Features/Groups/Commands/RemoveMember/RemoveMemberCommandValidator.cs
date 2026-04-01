using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.Commands.RemoveMember
{
    public sealed class RemoveMemberCommandValidator : AbstractValidator<RemoveMemberCommand>
    {
        public RemoveMemberCommandValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner ID cannot be empty");
            RuleFor(x => x.MemberId).NotEmpty().WithMessage("Member ID cannot be empty");
            RuleFor(x => x.GroupeId).NotEmpty().WithMessage("Group ID cannot be empty");
        }
    }
}
