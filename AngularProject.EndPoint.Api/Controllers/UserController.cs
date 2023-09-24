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
                return Ok(users);
            }
            catch
            {

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
                return Ok(user);
            }
            catch
            {

            }
            return Ok(response);
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] PostUserRequest request)
        {
            var response = new BaseUserResponse<CreateUserResponse>();
            try
            {
                await _services.PostUser(request.UserName, request.UserEmail, request.NationalCode, request.UserPasswordHash, request.PhoneNumber);
                return Ok();
            }
            catch
            {

            }
            return Ok(response);
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            var response = new BaseUserResponse<DeleteUserResponse>();
            try
            {
                await _services.DeleteUser(id);
                return Ok();
            }
            catch
            {

            }
            return Ok(response);
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest request)
        {
            var response = new BaseUserResponse<UpdateUserResponse>();
            try
            {
                await _services.UpdateUser(request.UserID,request.UserName,request.UserEmail,request.NationalCode,request.UserPasswordHash,request.PhoneNumber);
                return Ok();
            }
            catch
            {

            }
            return Ok(response);
        }
        #endregion
    }
}
