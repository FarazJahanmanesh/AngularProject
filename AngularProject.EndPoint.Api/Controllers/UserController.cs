﻿using AngularProject.Src.Core.Domain.common;
using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Core.Domain.Dtos.User;
using AngularProject.Src.Core.Domain.Entities;
using AngularProject.Src.Core.Domain.Entities.Request;
using AngularProject.Src.Core.Domain.Entities.Response;
using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
namespace AngularProject.Src.EndPoint.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        #region ctor
        private readonly IUserServices _services;
        private readonly IMapper _mapper;
        public UserController(IUserServices services, IMapper mapper)
        {
            _services = services;
            _mapper = mapper;
        }
        #endregion

        #region controllers
        [HttpGet]
        [Route("GetListUser")]
        public async Task<IActionResult> GetListUser()
        {
            var response = new BaseUserResponse<List<GetListUserResponse>>();
            try
            {
                var users = await _services.GetAllUser();
                if(users != null)
                {
                    response.Data = _mapper.Map<List<GetListUserResponse>>(users);
                    response.Status = 200;
                    response.Message = StaticStrings.Get_List_User_Successfuly;
                }
                else
                {
                    response.Status = 404;
                    response.Message = StaticStrings.Get_List_User_Not_Successfuly;
                }
            }
            catch
            {
                response.Status = 503;
                response.Message = StaticStrings.Problem_In_Calling_Service;
            }
            return Ok(response);
        }
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var response = new BaseUserResponse<GetUserByIdResponse>();
            try
            {
                var user = await _services.GetUserById(id);
                if(user != null)
                {
                    response.Data = _mapper.Map<GetUserByIdResponse>(user);
                    response.Status = 200;
                    response.Message = StaticStrings.Get_User_By_Id_Successfuly;
                }
                else
                {
                    response.Status = 404;
                    response.Message = StaticStrings.Get_User_By_Id_Not_Successfuly;
                }
            }
            catch
            {
                response.Status = 503;
                response.Message = StaticStrings.Problem_In_Calling_Service;
            }
            return Ok(response);
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] PostUserRequest request)
        {
            var response = new BaseUserResponse();
            try
            {
                var result = await _services.PostUser(request.UserName, request.UserEmail, request.NationalCode, request.UserPasswordHash, request.PhoneNumber);
                if(result == true)
                {
                    response.Status = 200;
                    response.Message = StaticStrings.Create_User_Successfuly;
                }
                else
                {
                    response.Status = 400;
                    response.Message = StaticStrings.Create_User_Not_Successfuly;
                }
            }
            catch
            {
                response.Status = 503;
                response.Message = StaticStrings.Problem_In_Calling_Service;
            }
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = new BaseUserResponse();
            try
            {
                var result = await _services.DeleteUser(id);
                if (result==true)
                {
                    response.Status=200;
                    response.Message = StaticStrings.Delete_User_Successfuly;
                }
                else
                {
                    response.Status = 400;
                    response.Message = StaticStrings.Delete_User_Not_Successfuly;
                }
            }
            catch
            {
                response.Status = 503;
                response.Message = StaticStrings.Problem_In_Calling_Service;
            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var response = new BaseUserResponse();
            try
            {
                var result = await _services.UpdateUser(request.UserID,request.UserName,request.UserEmail,request.NationalCode,request.UserPasswordHash,request.PhoneNumber);
                if(result==true)
                {
                    response.Status = 200;
                    response.Message = StaticStrings.Update_User_Successfuly;
                }
                else
                {
                    response.Status = 400;
                    response.Message = StaticStrings.Update_User_Not_Successfuly;
                }
            }
            catch
            {
                response.Status = 503;
                response.Message = StaticStrings.Problem_In_Calling_Service;
            }
            return Ok(response);
        }
        #endregion
    }
}
