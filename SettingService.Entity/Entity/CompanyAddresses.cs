using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using SettingService.Entity.Common.Interface;

namespace SettingService.Entity.Entity;

public class CompanyAddresses :BaseEntity
{
    [Key]
    [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
    public Guid Id { get; set; }
    public string Country { get; set; }
    public string AddressLine1 { get; set; }
    public string AddressLine2 { get; set; }
    public string TownLocality { get; set; }
    public string CityRegion { get; set; }
    public string State { get; set; }
    public string PostalZipcode { get; set; }
    public string TelephoneNo { get; set; }
    public string AddressType { get; set; }
    public DateTime CreatedTimeStamp { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedTimeStamp { get; set; } = DateTime.UtcNow;

    [ForeignKey("Company")]
    public Guid CompanyId { get; set; }
    public bool IsDeleted { get; set; }

}
