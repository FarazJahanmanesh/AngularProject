namespace AngularProject.Src.EndPoint.Api.Model.Response
{
    public class GetUserByIdResponse
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
        public bool IsDelete { get; set; }
    }
}
