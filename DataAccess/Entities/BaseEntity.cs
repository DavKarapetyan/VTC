using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VTC.DataAccess.Entities
{
    public class BaseEntity
    {
        public bool IsDeleted { get; set; }
        public DateTime CreatedDate { get; set; } = DateTime.Now;
    }
}
