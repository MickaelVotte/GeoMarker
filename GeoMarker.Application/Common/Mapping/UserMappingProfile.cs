using AutoMapper;
using GeoMarker.Application.Features.Users.DTOs;
using GeoMarker.Domain.Entities;


namespace GeoMarker.Application.Features.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<User, CreateUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
            CreateMap<User, LoginUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
            CreateMap<User, UpdateUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
            CreateMap<User, DesactiveUserResponse>();
            CreateMap<User, GetUserMarkersResponse>()
                .ForMember(dest => dest.Markers, opt => opt.MapFrom(src => src.Markers))
                .ForMember(dest => dest.UserId, opt => opt.MapFrom(src => src.Id));
            CreateMap<User, MarkerDto>();
               

        }
    }
}
