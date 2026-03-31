using FluentValidation;
using GeoMarker.Application.Features.Groups.Commands.AddMenber;


namespace GeoMarker.Application.Features.Groups.Commands.AddMember
{
    public sealed class AddMemberCommandValidator : AbstractValidator<AddMemberCommand>
    {
        public AddMemberCommandValidator()
        {
            RuleFor(x => x.OwnerId).NotEmpty().WithMessage("Owner ID cannot be empty");
            RuleFor(x => x.MemberId).NotEmpty().WithMessage("Member ID cannot be empty");
            RuleFor(x => x.GroupId).NotEmpty().WithMessage("Group ID cannot be empty");
        }
    }
}
