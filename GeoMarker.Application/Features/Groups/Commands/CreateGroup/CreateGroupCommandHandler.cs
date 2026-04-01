using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Groups.DTOs;
using GeoMarker.Application.Interfaces;
using GeoMarker.Domain.Entities;
using MediatR;
using AutoMapper;

namespace GeoMarker.Application.Features.Groups.Commands.CreateGroup
{
    public class CreateGroupCommandHandler : IRequestHandler<CreateGroupCommand, CreateGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;

        public CreateGroupCommandHandler(IGroupRepository groupRepository, IUserRepository userRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _userRepository = userRepository;
            _mapper = mapper;

        }

        public async Task<CreateGroupResponse> Handle(CreateGroupCommand request, CancellationToken cancellationToken)
        {
            var owner = await _userRepository.GetByIdAsync(request.OwnerId, cancellationToken);
            if (owner == null)
            {
                throw new Exception("Owner not found");
            }
            var group = new Group(
                name: request.Name,
                description: request.Description,
                ownerId: request.OwnerId
            );

            await _groupRepository.AddAsync(group, cancellationToken);

            return _mapper.Map<CreateGroupResponse>(group);
        }
    }
}