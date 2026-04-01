using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Groups.DTOs;
using GeoMarker.Application.Interfaces;
using MediatR;


namespace GeoMarker.Application.Features.Groups.Commands.RemoveMember
{
    public class RemoveMemberCommandHandler : IRequestHandler<RemoveMemberCommand, RemoveMemberResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;

        public RemoveMemberCommandHandler(IGroupRepository groupRepository, IUserRepository userRepository)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
        }


        public async Task<RemoveMemberResponse> Handle(RemoveMemberCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetByIdAsync(request.GroupeId, cancellationToken);
            if (group == null)
            {
                throw new Exception("Group not found");
            }
            var user = await _userRepository.GetByIdAsync(request.MemberId, cancellationToken);
            if (user == null)
            {
                throw new Exception("User not found");
            }
            if (group.OwnerId != request.OwnerId)
            {
                throw new Exception("Only the owner can remove members");
            }
            group.RemoveMember(user);
            await _groupRepository.UpdateAsync(group, cancellationToken);
            return new RemoveMemberResponse(request.MemberId, user.FirstName);
        }
    }
}