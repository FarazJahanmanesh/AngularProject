using AngularProject.Src.Core.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Src.Infra.Database
{
    public class AngularProjectDbContext : DbContext
    {
        public AngularProjectDbContext(DbContextOptions<AngularProjectDbContext> options):base(options)
        {
        }
        public DbSet<User> Users { get; set; }
    }
}
