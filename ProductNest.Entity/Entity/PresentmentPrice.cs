using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProductNest.Entity.Entity;

[Table("PresentmentPrice")]
public class PresentmentPrice: _Base
{
    public long PredentPriceId { get; set; }
    public Price Price { get; set; }
    public string CompareAtPrice { get; set; }
}
