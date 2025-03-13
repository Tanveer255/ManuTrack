using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingService.Entity.DTO;

public class PaymentDTO
{
    public Guid PaymentMethodId { get; set; }
    public string CustommerId { get; set; }
}
