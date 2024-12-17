using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.Entity.Entity;

[Table("Price")]
public class Price:_Base
{
    public long PriceId { get; set; }
    [Precision(18, 4)]
    public decimal Amount { get; set; }
    [Precision(18, 4)]
    public decimal CurrencyCode { get; set; }
    public long ProductId { get; set; }
    [Precision(18, 4)]
    public decimal UnitPrice { get; set; }
    [Precision(18, 4)]
    public decimal SellingPrice { get; set; }

}
