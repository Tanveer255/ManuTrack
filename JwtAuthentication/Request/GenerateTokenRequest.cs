using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Request;

public class GenerateTokenRequest
{
    public string Email { get; set; }     
    public Guid UserId { get; set; }     
}
