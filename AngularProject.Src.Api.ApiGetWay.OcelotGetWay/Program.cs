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
builder.Services.AddOcelot(builder.Configuration);
builder.Services.AddCors(options =>
{
    options.AddPolicy("MyCorsPolicy", builder => { builder.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod(); });
});
var app = builder.Build();
app.UseCors("MyCorsPolicy");
app.MapGet("/", () => "Hello World!");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
await app.UseOcelot();
app.Run();
