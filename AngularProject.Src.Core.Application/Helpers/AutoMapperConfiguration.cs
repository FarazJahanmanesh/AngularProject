using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularProject.Src.Core.Domain.Dtos.User;
using AngularProject.Src.Core.Domain.Entities;
using AutoMapper;

namespace AngularProject.Src.Core.Application.Helpers
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration() 
        {
            CreateMap<User, GetAllUserDetailDto>().ReverseMap();
            CreateMap<User, GetUserByIdDetailDto>().ReverseMap();
            CreateMap<User, PostUserDetailDto>().ReverseMap();
            CreateMap<User, UpdateUserDetailDto>().ReverseMap();
        }
    }
}
