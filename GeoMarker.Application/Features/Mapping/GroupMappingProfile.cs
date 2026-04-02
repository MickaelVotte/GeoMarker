using AutoMapper;
using GeoMarker.Application.Features.Groups.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Mapping
{
    public class GroupMappingProfile : Profile
    {
        public GroupMappingProfile()
        {
            CreateMap<Domain.Entities.Group, AddMemberResponse>();
            CreateMap<Domain.Entities.Group, CreateGroupResponse>();
            CreateMap<Domain.Entities.Group, DeleteGroupResponse>();
            CreateMap<Domain.Entities.Group, UpdateGroupResponse>();
        }
    }
}
