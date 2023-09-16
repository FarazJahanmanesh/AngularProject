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
        #region ctor
        private readonly IUserRepository _repository;
        public UserServices(IUserRepository repository)
        {
            _repository = repository;
        }
        #endregion

        #region crud
        public async Task DeleteUser(int id)
        {
            await _repository.DeleteUser(id);
        }

        public async Task<List<GetAllUserDetailDto>> GetAllUser()
        {
            try
            {
                return await _repository.GetAllUser();
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task<GetUserByIdDetailDto> GetUserById(int id)
        {
            try
            {
                return await _repository.GetUserById(id);
            }
            catch(Exception ex)
            {
                throw ex;
            }
        }

        public async Task PostUser(string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber)
        {
            try
            {
                await _repository.PostUser(userName,userEmail,nationalCode,userPasswordHash,phoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task UpdateUser(int userId, string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber)
        {
            try
            {
                await _repository.UpdateUser(updateUser);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
