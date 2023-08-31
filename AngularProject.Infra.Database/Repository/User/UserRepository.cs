using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Core.Domain.Dtos.User;
using UserEntitiy = AngularProject.Src.Core.Domain.Entities;
using AutoMapper;
using Microsoft.EntityFrameworkCore;

namespace AngularProject.Src.Infra.Database.Repository.User
{
    public class UserRepository: IUserRepository
    {
        private readonly AngularProjectDbContext _dbContext;
        private readonly IMapper _mapper;
        public UserRepository(AngularProjectDbContext dbContext, IMapper mapper)
        {
            _mapper=mapper;
            _dbContext = dbContext;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _dbContext.Users.FindAsync(id);
            user.IsDelete = true;
            await _dbContext.SaveChangesAsync();
        }

        public async Task<List<GetAllUserDetailDto>> GetAllUser()
        {
            var usrs = await _dbContext.Users.AsNoTracking().ToListAsync();
            return _mapper.Map<List<GetAllUserDetailDto>>(usrs);
        }

        public async Task<GetUserByIdDetailDto> GetUserById(int id)
        {
            var user = await _dbContext.Users.AsNoTracking().FirstOrDefaultAsync(c=>c.Id==id);
            return _mapper.Map<GetUserByIdDetailDto>(user);
        }

        public async Task PostUser(PostUserDetailDto postUser)
        {
            var newUser = _mapper.Map<UserEntitiy.User>(postUser);
            await _dbContext.Users.AddAsync(newUser);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateUser(UpdateUserDetailDto updateUser)
        {
            var user = await _dbContext.Users.FindAsync(updateUser.UserID);
            user.PhoneNumber = updateUser.PhoneNumber;
            user.UserName=updateUser.UserName;
            user.UserEmail=updateUser.UserEmail;
            user.UserPasswordHash= updateUser.UserPasswordHash;
            user.NationalCode=updateUser.NationalCode;
            await _dbContext.SaveChangesAsync();
        }
    }
}
