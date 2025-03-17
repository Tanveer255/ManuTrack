﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JwtAuthentication.Request;

public class RefreshTokenRequest
{
    public string RefreshToken { get; set; }
    public DateTime RefreshTokenExpiryTime { get; set; }
}
