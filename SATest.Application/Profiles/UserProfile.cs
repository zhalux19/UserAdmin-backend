using AutoMapper;
using SATest.Entities.Entities;
using SATest.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SATest.Application.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<User, UserDto>()
                .ForMember(
                    dest => dest.Gender,
                    opt => opt.MapFrom(src => src.IsMale ? "Male" : "Female")
                );

            CreateMap<UserForCreationDto, User>()
                .ForMember(
                    dest => dest.Id,
                    opt => opt.MapFrom(src => 0)
                );
        }
    }
}
