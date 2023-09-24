using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularProject.Src.Core.Domain.Dtos.User;
using AngularProject.Src.Core.Domain.Entities;
using AngularProject.Src.Core.Domain.Entities.Response;
using AutoMapper;

namespace AngularProject.Src.Core.Application.Helpers
{
    public class AutoMapperConfiguration:Profile
    {
        #region add mapp in ctor
        public AutoMapperConfiguration() 
        {
            CreateMap<User, GetAllUserDetailDto>().ReverseMap();
            CreateMap<User, GetUserByIdDetailDto>().ReverseMap();
            CreateMap<User, PostUserDetailDto>().ReverseMap();
            CreateMap<User, UpdateUserDetailDto>().ReverseMap();
            CreateMap<GetAllUserDetailDto, GetListUserResponse>().ReverseMap();
            CreateMap<GetUserByIdDetailDto, GetUserByIdResponse>().ReverseMap();
        }
        #endregion
    }
}
