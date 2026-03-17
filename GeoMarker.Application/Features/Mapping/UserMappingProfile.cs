using AutoMapper;
using GeoMarker.Application.Features.Users.DTOs;


namespace GeoMarker.Application.Features.Mapping
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Domain.Entities.User, CreateUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
            CreateMap<Domain.Entities.User, LoginUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
            CreateMap<Domain.Entities.User, UpdateUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }
    }
}
