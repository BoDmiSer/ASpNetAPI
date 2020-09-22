using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ASpNetAPI.Dtos;
using ASpNetAPI.Models;
using ASpNetAPI.ViewModel;
using AutoMapper;

namespace ASpNetAPI.Profiles
{
    public class TutorialProfile: Profile
    {
        public TutorialProfile()
        {
            CreateMap<PageTutorialViewModel, PageTutorialDto>();
            CreateMap<Tutorial, TutorialReadDto>();
            CreateMap<TutorialCreateDto, Tutorial>();
            CreateMap<TutorialUpdateDto, Tutorial>();
            CreateMap<Tutorial, TutorialUpdateDto>();
        }
    }
}
