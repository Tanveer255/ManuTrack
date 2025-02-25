using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingService.Entity.DTO;

public class StripePaymentRequestDTO
{
    public string Email { get; set; }
    public string PaymentMethodId { get; set; }
}
