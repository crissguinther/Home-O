using AutoMapper;
using Homeo.Domain;
using Homeo.DTOs.Request;

namespace Homeo.Application.Profiles {
    public class UserProfile : Profile {
        /// <summary>
        /// Used to map User DTOs from User domain entities
        /// </summary>
        public UserProfile() {
            CreateMap<UserRequestDTO, User>()
                .ForMember(dest => dest.UserName, opt => opt.MapFrom(source => source.Email));
            CreateMap<User, UserRequestDTO>();
        }
    }
}
