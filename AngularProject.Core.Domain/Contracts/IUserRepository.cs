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
        public Task<bool> PostUser(string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber);
        public Task<bool> UpdateUser(int userId, string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber);
        public Task<bool> DeleteUser(int id);
    }
}
