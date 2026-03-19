using AutoMapper;
using GeoMarker.Application.Features.Users.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GeoMarker.Application.Features.Mapping
{
    public class MarkerMappingProfile : Profile
    {
        public MarkerMappingProfile()
        {
            CreateMap<Domain.Entities.Marker, MarkerDto>();
        }
    }
}
