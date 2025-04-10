using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Model.Common;

public static class CommonUtils
{
    public static bool IsValidEmail(string email)
    {
        return !string.IsNullOrWhiteSpace(email) &&
               System.Text.RegularExpressions.Regex.IsMatch(email, @"^[^@\s]+@[^@\s]+\.[^@\s]+$");
    }

    public static string GenerateSlug(string input)
    {
        return input?.ToLower()
                     .Replace(" ", "-")
                     .Replace(".", "")
                     .Replace(",", "")
                     .Trim();
    }

    public static string GetFormattedDate(DateTime date)
    {
        return date.ToString("yyyy-MM-dd");
    }
}
