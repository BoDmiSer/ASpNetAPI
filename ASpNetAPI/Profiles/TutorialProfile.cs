using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASpNetAPI.Dtos;
using ASpNetAPI.Models;
using AutoMapper;

namespace ASpNetAPI.Profiles
{
    public class TutorialProfile: Profile
    {
        public TutorialProfile()
        {
            CreateMap<Tutorial, TutorialReadDto>();
            CreateMap<TutorialCreateDto, Tutorial>();
            CreateMap<TutorialUpdateDto, Tutorial>();
            CreateMap<Tutorial, TutorialUpdateDto>();
        }
    }
}
