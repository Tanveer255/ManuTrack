using AcessFlow.Entity.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessFlow.Entity.Entity
{
    public class _Base: IHasSoftDelete
    {
        public bool IsDeleted { get; set; }
        public DateTime UpdatedAt { get; set; }
    }
}
