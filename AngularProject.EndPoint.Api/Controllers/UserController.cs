using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Core.Domain.Dtos.User;
using AngularProject.Src.Core.Domain.Entities;
using AngularProject.Src.EndPoint.Api.Models;
using AngularProject.Src.EndPoint.Api.Models.Request;
using AngularProject.Src.EndPoint.Api.Models.Response;
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
        public UserController(IUserServices services)
        {
            _services = services;
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
                    response.Data = users;
                    return Ok(response);
                }
                else
                {
                    response.Status = 403;
                    response.Message = "error";
                }
            }
            catch
            {
                response.Status = 403;
                response.Message = "error";
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

                }
                else
                {
                    response.Status = 403;
                    response.Message = "error";
                }
                return Ok(user);
            }
            catch
            {
                response.Status = 403;
                response.Message = "error";
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
                    response.Message = "ok";
                }
                else
                {
                    response.Status = 403;
                    response.Message = "error";
                }
            }
            catch
            {
                response.Status = 403;
                response.Message = "error";
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
                    response.Message = "ok";
                }
                else
                {
                    response.Status = 403;
                    response.Message = "error";
                }
            }
            catch
            {
                response.Status = 403;
                response.Message = "error";
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
                    response.Message = "ok";
                }
                else
                {
                    response.Status = 403;
                    response.Message = "error";
                }
            }
            catch
            {
                response.Status = 403;
                response.Message = "error";
            }
            return Ok(response);
        }
        #endregion
    }
}
