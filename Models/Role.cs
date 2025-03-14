using System;
using System.Collections.Generic;

namespace IPL.Models;

public partial class Role
{
    public int RoleSeq { get; set; }

    public string? RoleName { get; set; }

    public decimal? CreatedBySeq { get; set; }

    public DateTime? CreatedByDtTm { get; set; }

    public decimal? ModifiedBySeq { get; set; }

    public DateTime? ModifiedDtTm { get; set; }

    public decimal? RecorVer { get; set; }
}
