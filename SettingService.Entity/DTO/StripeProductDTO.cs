using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingService.Entity.DTO;

public class StripeProductDTO
{
    public Guid Id { get; set; }
    public string Name { get; set; }
    public long Amount { get; set; }
    public string Currency { get; set; }
    public string Interval { get; set; }
}
