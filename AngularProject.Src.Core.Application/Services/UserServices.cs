using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Core.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Src.Core.Application.Services
{
    public class UserServices : IUserServices
    {
        private readonly IUserRepository _repository;
        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }
        public async Task DeleteUser(int id)
        {
            await _repository.DeleteUser(id);
        }

        public async Task<GetAllUserDetailDto> GetAllUser()
        {
            return await _repository.GetAllUser();
        }

        public async Task<GetUserByIdDetailDto> GetUserById(int id)
        {
            return await _repository.GetUserById(id);
        }

        public async Task PostUser()
        {
            await _repository.PostUser();
        }

        public async Task UpdateUser()
        {
            await _repository.UpdateUser();
        }
    }
}
