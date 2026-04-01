using FluentValidation;


namespace GeoMarker.Application.Features.Groups.Commands.DeleteGroup
{
    public sealed class DeleteGroupCommandValidator : AbstractValidator<DeleteGroupCommand>
    {
        public DeleteGroupCommandValidator()
        {
            RuleFor(x => x.GroupId)
                .NotEmpty().WithMessage("Group ID is required.");
            RuleFor(x => x.OwnerId)
                .NotEmpty().WithMessage("Owner ID is required.");
        }
    }
}
