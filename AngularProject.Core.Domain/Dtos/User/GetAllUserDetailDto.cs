﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Src.Core.Domain.Dtos.User
{
    public class GetAllUserDetailDto
    {
        public string UserName { get; set; }
        public string NationalCode { get; set; }
        public string PhoneNumber { get; set; }
    }
}
