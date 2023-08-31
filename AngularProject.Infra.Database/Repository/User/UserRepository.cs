using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Core.Domain.Dtos.User;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

        public async Task<GetAllUserDetailDto> GetAllUser()
        {
            throw new NotImplementedException();
        }

        public async Task<GetUserByIdDetailDto> GetUserById(int id)
        {
            throw new NotImplementedException();
        }

        public async Task PostUser()
        {
            throw new NotImplementedException();
        }

        public async Task UpdateUser()
        {
            throw new NotImplementedException();
        }
    }
}
