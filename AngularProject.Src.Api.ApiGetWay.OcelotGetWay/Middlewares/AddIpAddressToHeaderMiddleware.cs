namespace AngularProject.Src.Api.ApiGetWay.OcelotGetWay.Middlewares
{
    public class AddIpAddressToHeaderMiddleware
    {
        private readonly RequestDelegate _next;

        public AddIpAddressToHeaderMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var ipAddress = context.Connection.RemoteIpAddress.ToString();
            context.Request.Headers.Add("X-Forwarded-For", ipAddress);
            await _next(context);
        }
    }
}
