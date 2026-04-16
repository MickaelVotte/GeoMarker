using AutoMapper;
using GeoMarker.Application.Features.Groups.DTOs;
using GeoMarker.Domain.Entities;

namespace GeoMarker.Application.Features.Mapping
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Group, AddMemberResponse>();
            CreateMap<Group, CreateGroupResponse>();
            CreateMap<Group, DeleteGroupResponse>();
            CreateMap<Group, UpdateGroupResponse>();
        }
    }
}
