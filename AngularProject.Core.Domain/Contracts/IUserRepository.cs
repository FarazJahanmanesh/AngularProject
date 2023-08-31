using AngularProject.Src.Core.Domain.Dtos.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Src.Core.Domain.Contracts
{
    public interface IUserRepository
    {
        public Task<List<GetAllUserDetailDto>> GetAllUser();
        public Task<GetUserByIdDetailDto> GetUserById(int id);
        public Task PostUser(PostUserDetailDto postUser);
        public Task UpdateUser(UpdateUserDetailDto updateUser);
        public Task DeleteUser(int id);
    }
}
