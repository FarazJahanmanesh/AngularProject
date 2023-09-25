using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Core.Domain.Dtos.User;
using UserEntitiy = AngularProject.Src.Core.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularProject.Src.Infra.Database.Repository.User
{
    public class UserRepository: IUserRepository
    {
        #region ctor
        private readonly AngularProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(AngularProjectDbContext dbContext, IMapper mapper)
        {
            _mapper=mapper;
            _dbContext = dbContext;
        }
        #endregion

        #region crud
        private async Task<bool> SaveChangesAsync()
        {
            try
            {
                await _dbContext.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<bool> DeleteUser(int id)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(id);
                user.IsDelete = true;
                var result = await SaveChangesAsync();
                if(result==true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }
        public async Task<List<GetAllUserDetailDto>> GetAllUser()
        {
            try
            {
                var usrs = await _dbContext.Users.AsNoTracking().Where(c => c.IsDelete == false).ToListAsync();
                return _mapper.Map<List<GetAllUserDetailDto>>(usrs);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<GetUserByIdDetailDto> GetUserById(int id)
        {
            try
            {
                var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(c => c.Id == id);
                return _mapper.Map<GetUserByIdDetailDto>(user);
            }
            catch(Exception ex)
            {
                return null;
            }
        }

        public async Task<bool> PostUser(string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber)
        {
            try
            {
                var postUser = new PostUserDetailDto 
                {
                    NationalCode = nationalCode,
                    PhoneNumber = phoneNumber,
                    UserEmail = userEmail,
                    UserName = userName,
                    UserPasswordHash = userPasswordHash
                } ;
                var newUser = _mapper.Map<UserEntitiy.User>(postUser);
                await _dbContext.Users.AddAsync(newUser);
                var result = await SaveChangesAsync();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch
            {
                return false;
            }
        }

        public async Task<bool> UpdateUser(int userId, string userName, string userEmail, string nationalCode, string userPasswordHash, string phoneNumber)
        {
            try
            {
                var user = await _dbContext.Users.FindAsync(userId);
                user.PhoneNumber = phoneNumber;
                user.UserName = userName;
                user.UserEmail = userEmail;
                user.UserPasswordHash = userPasswordHash;
                user.NationalCode = nationalCode;
                var result = await SaveChangesAsync();
                if (result == true)
                {
                    return true;
                }
                else
                {
                    return false;
                }
                return true;
            }
            catch 
            {
                return false;
            }
        }
        #endregion
    }
}
