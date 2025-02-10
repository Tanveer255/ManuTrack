using Microsoft.EntityFrameworkCore;
using SettingService.Entity.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingService.Entity.Data;

public class SettingServiceDbContext(DbContextOptions<SettingServiceDbContext> options) : DbContext(options)
{
    DbSet<Company> Company { get; set; }
    DbSet<CompanyAddresses> CompanyAddresses { get; set; }
}
