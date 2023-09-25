using AngularProject.Src.Api.ApiGetWay.OcelotGetWay.Middlewares;
using Ocelot.DependencyInjection;
using Ocelot.Middleware;

var builder = WebApplication.CreateBuilder(args);
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
string ocelotName = "";
if (builder.Environment.IsDevelopment())
{
    ocelotName = "ocelot.development.json";
}
else
{
    ocelotName = "ocelot.production.json";
}
builder.Configuration.AddJsonFile(ocelotName, optional: false, reloadOnChange: false);
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});
var app = builder.Build();
app.UseCors("MyCorsPolicy");
app.MapGet("/", () => "Hello World!");
app.UseMiddleware<AddIpAddressToHeaderMiddleware>();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();
app.Run();
