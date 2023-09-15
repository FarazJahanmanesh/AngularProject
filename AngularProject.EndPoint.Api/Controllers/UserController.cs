using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Core.Domain.Dtos.User;
using AngularProject.Src.Core.Domain.Entities;
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
            var users  = await _services.GetAllUser();
            return Ok(users);
        }
        [HttpGet]
        [Route("GetUserById/{id}")]
        public async Task<IActionResult> GetUserById(int id)
        {
            var user = await _services.GetUserById(id);
            return Ok(user);
        }
        [HttpPost]
        [Route("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] PostUserDetailDto request)
        {
            await _services.PostUser(request);
            return Ok();
        }
        [HttpDelete]
        [Route("DeleteUser/{id}")]
        public async Task<IActionResult> DeleteUser(int id)
        {
            await _services.DeleteUser(id);
            return Ok();
        }

        [HttpPut]
        [Route("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserDetailDto request)
        {
            await _services.UpdateUser(request);
            return Ok();
        }
        #endregion
    }
}
