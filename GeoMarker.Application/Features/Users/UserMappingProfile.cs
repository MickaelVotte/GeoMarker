using AutoMapper;
using GeoMarker.Application.Features.Users.DTOs;


namespace GeoMarker.Application.Features.Users
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile()
        {
            CreateMap<Domain.Entities.User, CreateUserResponse>()
                .ForMember(dest => dest.Token, opt => opt.Ignore());
        }
    }
}
