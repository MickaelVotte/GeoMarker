using AutoMapper;
using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Groups.DTOs;
using GeoMarker.Application.Interfaces;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Groups.Commands.UpdateGroup
{
    public class UpdateGroupCommandHandler : IRequestHandler<UpdateGroupCommand, UpdateGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public UpdateGroupCommandHandler(
            IGroupRepository groupRepository,
            IUserRepository user,
            IMapper mapper)
        {
            _groupRepository = groupRepository;
            _userRepository = user;
            _mapper = mapper;
        }

        public async Task<UpdateGroupResponse> Handle(UpdateGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetByIdAsync(request.GroupId, cancellationToken);
            if (group == null)
            {
                throw new Exception("Group not found");
            }

            if (group.OwnerId != request.OwnerId)
            {
                throw new Exception("Only the owner can update the group");
            }

            group.UpdateName(request.Name);
            group.UpdateDescription(request.Description);

            await _groupRepository.UpdateAsync(group, cancellationToken);

            return _mapper.Map<UpdateGroupResponse>(group);
        }
    }
}
