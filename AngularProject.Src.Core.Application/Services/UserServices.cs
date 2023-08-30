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
        public Task DeleteUser(int id)
        {
            throw new NotImplementedException();
        }

        public Task<GetAllUserDetailDto> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public Task<GetUserByIdDetailDto> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public Task PostUser()
        {
            throw new NotImplementedException();
        }

        public Task UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
