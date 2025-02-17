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

    public SendGridSettings sendGridSettings { get; set; }
    public static string ApplicationEmailValidationEnabled { get; set; }
}
public class SendGridSettings {
    public static string EmailApiKey { get; set; }

    public static string ValidationApiKey { get; set; }

    public static string FromEmail { get; set; }
}
public class ReCaptchaSettings
{
    public static string SiteKey { get; set; }
    public static string SecretKey { get; set; }
    public static string Url { get; set; }
}