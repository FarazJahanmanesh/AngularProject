using AppAutoMapper = AngularProject.Src.Core.Application.Helpers;
using AngularProject.Src.Core.Application.Services;
using AngularProject.Src.Core.Domain.Contracts;
using AngularProject.Src.Infra.Database;
using Microsoft.EntityFrameworkCore;
using EndAutoMapper = AngularProject.Src.EndPoint.Api.Helpers;
using AngularProject.Src.Infra.Database.Repository.User;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
var connectionString = builder.Configuration.GetConnectionString("AngularProject");
builder.Services.AddDbContext<AngularProjectDbContext>(options => options.UseSqlServer(connectionString));
builder.Services.AddAutoMapper(typeof(AppAutoMapper.AutoMapperConfiguration).Assembly);
builder.Services.AddAutoMapper(typeof(EndAutoMapper.AutoMapperConfiguration).Assembly);
builder.Services.AddScoped<IUserServices, UserServices>();
builder.Services.AddScoped<IUserRepository, UserRepository>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
