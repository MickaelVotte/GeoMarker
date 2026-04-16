using AutoMapper;
using GeoMarker.Application.Features.Markers.DTOs;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Domain.Entities;


namespace GeoMarker.Application.Features.Mapping
{
    public class MarkerMappingProfile : Profile
    {
        public MarkerMappingProfile()
        {
            CreateMap<Marker, MarkerDto>();
            CreateMap<Marker, AddMarkerResponse>();
            CreateMap<Marker, DeleteMarkerResponse>();
            CreateMap<Marker, UpdateMarkerResponse>();

        }
    }
}
