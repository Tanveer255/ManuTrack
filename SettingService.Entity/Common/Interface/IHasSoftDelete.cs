using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SettingService.Entity.Common.Interface;

public interface IHasSoftDelete
{
    public bool IsDeleted { get; set; }
    DateTime UpdatedAt { get; set; }
}
