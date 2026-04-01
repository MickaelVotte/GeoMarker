using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandValidator : AbstractValidator<UpdateGroupCommand>
    {
        public UpdateGroupCommandValidator()
        {
            RuleFor(x => x.GroupId).NotEmpty().WithMessage("Group ID cannot be empty");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner ID cannot be empty");
            RuleFor(x => x.Name).NotEmpty().WithMessage("Group name cannot be empty");
        }
    }
}
