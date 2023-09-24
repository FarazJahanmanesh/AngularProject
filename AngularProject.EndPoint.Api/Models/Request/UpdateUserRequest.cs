﻿namespace AngularProject.Src.EndPoint.Api.Models.Request
{
    public class UpdateUserRequest
    {
        public int UserID { get; set; }
        public string UserName { get; set; }
        public string UserEmail { get; set; }
        public string NationalCode { get; set; }
        public string UserPasswordHash { get; set; }
        public string PhoneNumber { get; set; }
    }
}