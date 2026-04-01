using GeoMarker.Application.Common.Interfaces.Persistence;
using GeoMarker.Application.Features.Groups.Commands.DeleteGroup;
using GeoMarker.Application.Features.Groups.DTOs;
using GeoMarker.Application.Interfaces;
using MediatR;
using AutoMapper;


namespace GeoMarker.Application.Features.Groups.Commands.DeleteGroup
{
    public class DeleteGroupCommandHandler : IRequestHandler<DeleteGroupCommand, DeleteGroupResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public DeleteGroupCommandHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public async Task<DeleteGroupResponse> Handle(DeleteGroupCommand request, CancellationToken cancellationToken)
        {
            var group = await _groupRepository.GetByIdAsync(request.GroupId, cancellationToken);
            if (group == null)
            {
                throw new Exception("Group not found");
            }

            await _groupRepository.DeleteAsync(group, cancellationToken);
            return _mapper.Map<DeleteGroupResponse>(group);
        }
    }
}
