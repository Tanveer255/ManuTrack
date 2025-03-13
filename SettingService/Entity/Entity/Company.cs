using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.Metrics;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SettingService.Entity.Entity;

/// <summary>
/// This is the Company class which holds all data related to Company and has some properties given below.
/// </summary>
[Table(nameof(Company))]
public class Company : BaseEntity
{

    [Required(ErrorMessage = "Please Enter Warehouse Name")]
    public string Name { get; set; }

    public string TenantId { get; set; }

    [Required(ErrorMessage = "Please Enter Email")]
    [RegularExpression(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*", ErrorMessage = "Please enter a valid email address")]
    public string Email { get; set; }

    public string PhoneNumber { get; set; }
    public string FaxNumber { get; set; }
    public string PrimaryBusiness { get; set; }
    public string CompanyRegNo { get; set; }
    public string TaxId { get; set; }
    public string WebsiteAddress { get; set; }
    public string GeneralEmail { get; set; }
    public bool IsUpdated { get; set; }
    public List<CompanyAddresses> CompanyAddresses { get; set; }

    //[JsonIgnore]
    //public List<User> Users { get; set; }

    public void Update(Company company)
    {
        Name = company.Name;
        Email = company.Email;
        PhoneNumber = company.PhoneNumber;
        FaxNumber = company.FaxNumber;
        UpdatedAt = DateTime.UtcNow;
        PrimaryBusiness = company.PrimaryBusiness;
        CompanyRegNo = company.CompanyRegNo;
        TaxId = company.TaxId;
        WebsiteAddress = company.WebsiteAddress;
        GeneralEmail = company.GeneralEmail;
        TenantId = company.TenantId;
        IsUpdated = company.IsUpdated;
    }

    public void MakeTenantId()
    {
        var companyShortCode = new string(Name.Replace(" ", string.Empty).ToLower().Take(3).ToArray());
        TenantId = companyShortCode + DateTime.UtcNow.ToString("yyMMddHHmmss");
    }

    //public string GetCountryName(string code, IEnumerable<Country> countries)
    //{
    //    var name = string.Empty;
    //    Country country = null;
    //    if (string.IsNullOrEmpty(code))
    //    {
    //        name = "-";
    //    }
    //    else if (code.Length == 2)
    //    {
    //        country = countries.Where(c => c.AlphaTwoCode == code).FirstOrDefault();
    //    }
    //    else if (code.Length == 3)
    //    {
    //        country = countries.Where(c => c.AlphaThreeCode == code).FirstOrDefault();
    //    }
    //    else if (code.Length > 3)
    //    {
    //        name = code;
    //    }

    //    if (country != null)
    //    {
    //        name = country.Name;
    //    }

    //    return name;
    //}
}
