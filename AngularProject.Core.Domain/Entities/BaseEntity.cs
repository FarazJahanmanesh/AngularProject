using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AngularProject.Src.Core.Domain.Entities
{
    public class BaseEntity<T>
    {
        public T Id { get; set; }
        public bool IsDelete { get; set; }
    }
    public class BaseEntity: BaseEntity<int>
    {
    }
}
