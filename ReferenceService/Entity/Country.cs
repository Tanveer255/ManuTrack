namespace ReferenceService.Entity;

public class Country :BaseEntity
{
    public string Code { get; set; } // ISO Alpha-2 (e.g., "US"), Alpha-3 (e.g., "USA"), or Numeric (e.g., 840)
    public string Name { get; set; } // Full country name (e.g., "United States")
    public string CurrencyCode { get; set; } // ISO 4217 currency code (e.g., "USD")
    public string CurrencySign { get; set; } // Currency Symbol (e.g., "$")
    public string DialingCode { get; set; } // Country Calling Code (e.g., "+1")
    public string TimeZone { get; set; } // Time Zone (e.g., "UTC-5")
    public string FlagUrl { get; set; } // Optional: URL to flag image

    // Navigation Property
    public List<State> States { get; set; } = new List<State>();
}

