using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingService.Entity.DTO;

public class SubsCriptionDTO
{
    public Guid Id { get; set; }
    public string CustomerId { get; set; }
    public string ProductId { get; set; }
}
