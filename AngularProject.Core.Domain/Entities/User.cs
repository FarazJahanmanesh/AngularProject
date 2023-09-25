using AngularProject.Src.Core.Domain.common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Src.Core.Domain.Entities
{
    public class User:BaseEntity
    {
        #region props
        public string UserName {get; set;}
        public string UserEmail { get; set;}
        public string NationalCode {get;set;}
        public string UserPasswordHash { get; set; } 
        public string PhoneNumber {get; set;}
        #endregion
    }
}
