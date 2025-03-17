using System;
using System.Collections.Generic;

namespace IPL.Models;

public partial class Ipl
{
    public int IplSeq { get; set; }

    public string? IplName { get; set; }

    public string? IplYear { get; set; }

    public string? Sponsor { get; set; }

    public decimal? NoOfTeams { get; set; }

    public decimal? CreatedBySeq { get; set; }

    public DateTime? CreatedByDtTm { get; set; }

    public decimal? ModifiedBySeq { get; set; }

    public DateTime? ModifiedDtTm { get; set; }

    public decimal? RecorVer { get; set; }

    public virtual ICollection<Team> Teams { get; set; } = new List<Team>();
}
