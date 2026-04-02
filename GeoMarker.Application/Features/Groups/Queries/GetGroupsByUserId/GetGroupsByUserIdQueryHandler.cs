using GeoMarker.Application.Features.Groups.DTOs;
using MediatR;
using AutoMapper;
using GeoMarker.Application.Interfaces;

namespace GeoMarker.Application.Features.Groups.Queries.GetGroupsByUserId
{
    public class GetGroupsByUserIdQueryHandler : IRequestHandler<GetGroupsByUserIdQuery, GetGroupsByUserIdResponse>
    {
        private readonly IGroupRepository _groupRepository;
        private readonly IMapper _mapper;
        public GetGroupsByUserIdQueryHandler(IGroupRepository groupRepository, IMapper mapper)
        {
            _groupRepository = groupRepository;
            _mapper = mapper;
        }

        public async Task<GetGroupsByUserIdResponse> Handle(GetGroupsByUserIdQuery request, CancellationToken cancellationToken)
        {
            var groups = await _groupRepository.GetGroupsByUserIdAsync(request.UserId, cancellationToken);
            var groupDtos = _mapper.Map<IReadOnlyList<GroupInfoDto>>(groups);
            return new GetGroupsByUserIdResponse(request.UserId, groupDtos);
        }
    }
}
