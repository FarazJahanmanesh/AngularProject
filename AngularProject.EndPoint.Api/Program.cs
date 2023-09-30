using AppAutoMapper = AngularProject.Src.Core.Application.Helpers;
using AngularProject.Src.Core.Application.Services;
using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Infra.Database;
using Microsoft.EntityFrameworkCore;
using AngularProject.Src.Infra.Database.Repository.User;
using IOC.Dependencies;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

#region add dbcontext config
var connectionString = builder.Configuration.GetConnectionString("AngularProject");
builder.Services.AddDbContext<AngularProjectDbContext>(options => options.UseSqlServer(connectionString));
#endregion

#region add config for automappe
builder.Services.AddAutoMapper(typeof(AppAutoMapper.AutoMapperConfiguration).Assembly);
#endregion

#region add di
builder.Services.RegisterServices();
#endregion

#region Add cors
builder.Services.AddCors(options =>
{
    options.AddPolicy("ClientPermission", policy =>
    {
        policy.AllowAnyHeader()
            .AllowAnyMethod()
            .SetIsOriginAllowed(_ => true)
            .AllowCredentials();
    });
});

#endregion

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

#region add cors
app.UseCors("ClientPermission");

#endregion

app.UseAuthorization();

app.MapControllers();

app.Run();
