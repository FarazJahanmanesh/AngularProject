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
        public Task<GetAllUserDetailDto> GetAllUser();
        public Task<GetUserByIdDetailDto> GetUserById(int id);
        public Task PostUser();
        public Task UpdateUser();
        public Task DeleteUser(int id);
    }
}
