using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Entities;
using UrlShortener.Models;

namespace UrlShortener.Profiles
{
    public class UrlProfile : Profile 
    {

        public UrlProfile()
        {
            CreateMap<UrlForCreationDto, Url>();
            CreateMap<UrlForUpdateDto, Url>();
            CreateMap<UrlDto, Url>();
        }

    }
}
