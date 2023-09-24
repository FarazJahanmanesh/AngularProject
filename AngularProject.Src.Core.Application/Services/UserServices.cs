using AngularProject.Src.Core.Application.Helpers;
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
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var response = await _repository.DeleteUser(id);
                return response;
            }
            catch(Exception ex)
            {
                throw ex;
            }
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

        public async Task<bool> PostUser(string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber)
        {
            try
            {
                return await _repository.PostUser(userName,userEmail,nationalCode,userPasswordHash.SHA1HashCode(), phoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public async Task<bool> UpdateUser(int userId, string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber)
        {
            try
            {
                return await _repository.UpdateUser(userId,userName,userEmail,nationalCode,userPasswordHash.SHA1HashCode(), phoneNumber);
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
