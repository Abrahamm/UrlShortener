using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UrlShortener.Entities;
using UrlShortener.Models;

namespace UrlShortener.Profiles
{
    public class UserProfile : Profile 
    {

        public UserProfile()
        {
            CreateMap<User, UserWithoutUrlsDto>();
            CreateMap<User, UserForCreationDto>();
            CreateMap<UserForCreationDto, User>();
            CreateMap<UserForUpdateDto, User>();
            CreateMap<User, UserWithUrlsDto>();
            CreateMap<UserWithUrlsDto, User>();
            //UserWithUrlsDto > (userEntity
        }

    }
}
