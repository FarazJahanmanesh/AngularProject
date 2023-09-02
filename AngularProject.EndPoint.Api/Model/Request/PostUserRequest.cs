namespace AngularProject.Src.EndPoint.Api.Model.Request
{
    public class PostUserRequest
    {
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string NationalCode { get; set; }
        public string UserPasswordHash { get; set; }
        public string PhoneNumber { get; set; }
    }
}
