using System;
using System.Collections.Generic;

namespace IPL.Models;

public partial class Player
{
    public int PlayerSeq { get; set; }

    public string? PlayerName { get; set; }

    public int? JerseyNo { get; set; }

    public string? Country { get; set; }

    public string? ForeignerFl { get; set; }

    public decimal? CreatedBySeq { get; set; }

    public DateTime? CreatedByDtTm { get; set; }

    public decimal? ModifiedBySeq { get; set; }

    public DateTime? ModifiedDtTm { get; set; }

    public decimal? RecorVer { get; set; }

    public virtual ICollection<PlayerPurchase> PlayerPurchases { get; set; } = new List<PlayerPurchase>();
}
