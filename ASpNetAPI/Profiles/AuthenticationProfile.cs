using ASpNetAPI.Dtos.AuthenticationDtos;
using ASpNetAPI.Models.Authentication;
using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ASpNetAPI.Profiles
{
    public class AuthenticationProfile : Profile
    {
        public AuthenticationProfile()
        {
            CreateMap<LoginUserDto, User>();
            CreateMap<RegisterUserDto, User>();
        }
    }
}
