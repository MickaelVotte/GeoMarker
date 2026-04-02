using MediatR;
using AutoMapper;
using GeoMarker.Application.Features.Groups.DTOs;
using GeoMarker.Application.Interfaces;

namespace GeoMarker.Application.Features.Groups.Queries.GetGroupsByMarkerId
{
    public class GetGroupsByMarkerIdQueryHandler : IRequestHandler<GetGroupsByMarkerIdQuery, GetGroupsByMarkerIdResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GetGroupsByMarkerIdQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }
        public async Task<GetGroupsByMarkerIdResponse> Handle(GetGroupsByMarkerIdQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetGroupsByMarkerIdAsync(request.MarkerId, cancellationToken);
            var groupDtos =_mapper.Map<IReadOnlyList<GroupInfoDto>>(groups);
            return new GetGroupsByMarkerIdResponse(request.MarkerId, groupDtos);
        }
    }
}