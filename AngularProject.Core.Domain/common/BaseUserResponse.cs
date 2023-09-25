using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Src.Core.Domain.common
{
    public class BaseUserResponse<T>
    {
        public int Status { get; set; }
        public string Message { get; set; }
        public T Data { get; set; }
    }
    public class BaseUserResponse : BaseUserResponse<BaseUserResponse>
    {
        public int Status { get; set; }
        public string Message { get; set; }
    }
}
