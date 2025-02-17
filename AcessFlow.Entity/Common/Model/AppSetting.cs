using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessFlow.Entity.Common.Model;

public class AppSetting
{
    public static string ConnectionString { get; set; }

    public static string ReCaptchaSiteKey { get; set; }

    public static string ReCaptchaSecretKey { get; set; }

    public static string ReCaptchaUrl { get; set; }

    public static string SendGridEmailApiKey { get; set; }

    public static string SendGridValidationApiKey { get; set; }

    public static string SendGridFromEmail { get; set; }

    public static string ApplicationEmailValidationEnabled { get; set; }
}
