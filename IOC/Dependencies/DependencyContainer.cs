using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AngularProject.Src.Core.Application.Services;
using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Infra.Database.Repository.User;
using Microsoft.Extensions.DependencyInjection;


namespace IOC.Dependencies
{
    public static class DependencyContainer
    {
        public static void RegisterServices(this IServiceCollection services)
        {
            #region Services
            services.AddScoped<IUserServices, UserServices>();
            #endregion

            #region repo
            services.AddScoped<IUserRepository, UserRepository>();
            #endregion
        }
    }
}
