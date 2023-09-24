namespace AngularProject.Src.EndPoint.Api.Models
{
    public class BaseUserResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class BaseUserResponse: BaseUserResponse<BaseUserResponse>
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
