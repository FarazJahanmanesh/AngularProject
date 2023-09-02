using AngularProject.Src.Core.Domain.Dtos.User;
using AngularProject.Src.EndPoint.Api.Model.Request;
using AngularProject.Src.EndPoint.Api.Model.Response;
using AutoMapper;

namespace AngularProject.Src.EndPoint.Api.Helpers
{
    public class AutoMapperConfiguration:Profile
    {
        public AutoMapperConfiguration()
        {
            CreateMap<PostUserDetailDto, PostUserRequest>().ReverseMap();
            CreateMap<UpdateUserDetailDto, UpdateUserRequest>().ReverseMap();
            CreateMap<GetUserByIdResponse, GetUserByIdDetailDto>().ReverseMap();
            CreateMap<GetAllUserResponse, GetAllUserDetailDto>().ReverseMap();
        }
    }
}
