﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessFlow.Entity.Common;
public class Country
{
    public string Code { get; set; }
    public string Name { get; set; }
}

public class CountryList
{
    public List<Country> Countries { get; set; }

    public CountryList()
    {
        Countries = new List<Country>
        {
            new Country { Name = "Albania", Code = "🇦🇱" },
            new Country { Name = "Algeria", Code = "🇩🇿" },
            new Country { Name = "Angola", Code = "🇦🇴" },
            new Country { Name = "Antigua & Barbuda", Code = "🇦🇬" },
            new Country { Name = "Argentina", Code = "🇦🇷" },
            new Country { Name = "Armenia", Code = "🇦🇲" },
            new Country { Name = "Australia", Code = "🇦🇺" },
            new Country { Name = "Austria", Code = "🇦🇹" },
            new Country { Name = "Azerbaijan", Code = "🇦🇿" },
            new Country { Name = "Bahamas", Code = "🇧🇸" },
            new Country { Name = "Bahrain", Code = "🇧🇭" },
            new Country { Name = "Belgium", Code = "🇧🇪" },
            new Country { Name = "Benin", Code = "🇧🇯" },
            new Country { Name = "Bhutan", Code = "🇧🇹" },
            new Country { Name = "Bolivia", Code = "🇧🇴" },
            new Country { Name = "Botswana", Code = "🇧🇼" },
            new Country { Name = "Bosnia & Herzegovina", Code = "🇧🇦" },
            new Country { Name = "Brazil", Code = "🇧🇷" },
            new Country { Name = "Brunei", Code = "🇧🇳" },
            new Country { Name = "Bulgaria", Code = "🇧🇬" },
            new Country { Name = "Cambodia", Code = "🇰🇭" },
            new Country { Name = "Canada", Code = "🇨🇦" },
            new Country { Name = "Chile", Code = "🇨🇱" },
            new Country { Name = "Colombia", Code = "🇨🇴" },
            new Country { Name = "Costa Rica", Code = "🇨🇷" },
            new Country { Name = "Croatia", Code = "🇭🇷" },
            new Country { Name = "Cyprus", Code = "🇨🇾" },
            new Country { Name = "Czech Republic", Code = "🇨🇿" },
            new Country { Name = "Côte d'Ivoire", Code = "🇨🇮" },
            new Country { Name = "Denmark", Code = "🇩🇰" },
            new Country { Name = "Dominican Republic", Code = "🇩🇴" },
            new Country { Name = "Ecuador", Code = "🇪🇨" },
            new Country { Name = "Egypt", Code = "🇪🇬" },
            new Country { Name = "El Salvador", Code = "🇸🇻" },
            new Country { Name = "Estonia", Code = "🇪🇪" },
            new Country { Name = "Ethiopia", Code = "🇪🇹" },
            new Country { Name = "Finland", Code = "🇫🇮" },
            new Country { Name = "France", Code = "🇫🇷" },
            new Country { Name = "Gabon", Code = "🇬🇦" },
            new Country { Name = "Gambia", Code = "🇬🇲" },
            new Country { Name = "Germany", Code = "🇩🇪" },
            new Country { Name = "Ghana", Code = "🇬🇭" },
            new Country { Name = "Gibraltar", Code = "🇬🇮" },
            new Country { Name = "Greece", Code = "🇬🇷" },
            new Country { Name = "Guatemala", Code = "🇬🇹" },
            new Country { Name = "Guyana", Code = "🇬🇾" },
            new Country { Name = "Hong Kong SAR China", Code = "🇭🇰" },
            new Country { Name = "Hungary", Code = "🇭🇺" },
            new Country { Name = "Iceland", Code = "🇮🇸" },
            new Country { Name = "India", Code = "🇮🇳" },
            new Country { Name = "Ireland", Code = "🇮🇪" },
            new Country { Name = "Israel", Code = "🇮🇱" },
            new Country { Name = "Italy", Code = "🇮🇹" },
            new Country { Name = "Jamaica", Code = "🇯🇲" },
            new Country { Name = "Japan", Code = "🇯🇵" },
            new Country { Name = "Jordan", Code = "🇯🇴" },
            new Country { Name = "Kenya", Code = "🇰🇪" },
            new Country { Name = "Kuwait", Code = "🇰🇼" },
            new Country { Name = "Laos", Code = "🇱🇦" },
            new Country { Name = "Latvia", Code = "🇱🇻" },
            new Country { Name = "Liechtenstein", Code = "🇱🇮" },
            new Country { Name = "Lithuania", Code = "🇱🇹" },
            new Country { Name = "Luxembourg", Code = "🇱🇺" },
            new Country { Name = "Macao SAR China", Code = "🇲🇴" },
            new Country { Name = "Madagascar", Code = "🇲🇬" },
            new Country { Name = "Malaysia", Code = "🇲🇾" },
            new Country { Name = "Malta", Code = "🇲🇹" },
            new Country { Name = "Mauritius", Code = "🇲🇺" },
            new Country { Name = "Mexico", Code = "🇲🇽" },
            new Country { Name = "Moldova", Code = "🇲🇩" },
            new Country { Name = "Monaco", Code = "🇲🇨" },
            new Country { Name = "Mongolia", Code = "🇲🇳" },
            new Country { Name = "Morocco", Code = "🇲🇦" },
            new Country { Name = "Mozambique", Code = "🇲🇿" },
            new Country { Name = "Namibia", Code = "🇳🇦" },
            new Country { Name = "Netherlands", Code = "🇳🇱" },
            new Country { Name = "New Zealand", Code = "🇳🇿" },
            new Country { Name = "Niger", Code = "🇳🇪" },
            new Country { Name = "Nigeria", Code = "🇳🇬" },
            new Country { Name = "North Macedonia", Code = "🇲🇰" },
            new Country { Name = "Norway", Code = "🇳🇴" },
            new Country { Name = "Oman", Code = "🇴🇲" },
            new Country { Name = "Panama", Code = "🇵🇦" },
            new Country { Name = "Paraguay", Code = "🇵🇾" },
            new Country { Name = "Peru", Code = "🇵🇪" },
            new Country { Name = "Philippines", Code = "🇵🇭" },
            new Country { Name = "Poland", Code = "🇵🇱" },
            new Country { Name = "Portugal", Code = "🇵🇹" },
            new Country { Name = "Qatar", Code = "🇶🇦" },
            new Country { Name = "Pakistan", Code = "🇵🇰" },
            new Country { Name = "Romania", Code = "🇷🇴" },
            new Country { Name = "Rwanda", Code = "🇷🇼" },
            new Country { Name = "San Marino", Code = "🇸🇲" },
            new Country { Name = "Saudi Arabia", Code = "🇸🇦" },
            new Country { Name = "Senegal", Code = "🇸🇳" },
            new Country { Name = "Serbia", Code = "🇷🇸" },
            new Country { Name = "Singapore", Code = "🇸🇬" },
            new Country { Name = "Slovakia", Code = "🇸🇰" },
            new Country { Name = "Slovenia", Code = "🇸🇮" },
            new Country { Name = "South Africa", Code = "🇿🇦" },
            new Country { Name = "South Korea", Code = "🇰🇷" },
            new Country { Name = "Spain", Code = "🇪🇸" },
            new Country { Name = "Sri Lanka", Code = "🇱🇰" },
            new Country { Name = "St. Lucia", Code = "🇱🇨" },
            new Country { Name = "Sweden", Code = "🇸🇪" },
            new Country { Name = "Switzerland", Code = "🇨🇭" },
            new Country { Name = "Taiwan", Code = "🇹🇼" },
            new Country { Name = "Tanzania", Code = "🇹🇿" },
            new Country { Name = "Thailand", Code = "🇹🇭" },
            new Country { Name = "Trinidad & Tobago", Code = "🇹🇹" },
            new Country { Name = "Tunisia", Code = "🇹🇳" },
            new Country { Name = "Turkey", Code = "🇹🇷" },
            new Country { Name = "United Arab Emirates", Code = "🇦🇪" },
            new Country { Name = "United Kingdom", Code = "🇬🇧" },
            new Country { Name = "United States", Code = "🇺🇸" },
            new Country { Name = "Uruguay", Code = "🇺🇾" },
            new Country { Name = "Uzbekistan", Code = "🇺🇿" },
            new Country { Name = "Vietnam", Code = "🇻🇳" }
        };
    }
}

