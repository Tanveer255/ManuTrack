using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.Entity.Entity
{
    [Table("Price")]
    public class Price:_Base
    {
        public string Amount { get; set; }
        public string CurrencyCode { get; set; }
    }
}
