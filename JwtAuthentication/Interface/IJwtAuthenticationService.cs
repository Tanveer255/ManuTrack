using JwtAuthentication.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.Interface
{
    public  interface IJwtAuthenticationService
    {

        public string GenerateJwtToken(string username);
    }
}
