using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.Commands.CreateGroup
{
    public sealed class CreateGroupCommandValidator : AbstractValidator<CreateGroupCommand>
    {
        public CreateGroupCommandValidator()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("Group name cannot be empty");
            RuleFor(x => x.Name).MaximumLength(100).WithMessage("Group name cannot be longer than 100 characters");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Group description cannot be longer than 500 characters");
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner ID cannot be empty");
        }
    }
}
