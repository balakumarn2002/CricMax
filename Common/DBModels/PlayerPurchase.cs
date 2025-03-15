using System;
using System.Collections.Generic;

namespace IPL.Common.DBModels;

public partial class PlayerPurchase
{
    public int PlayerPurchaseSeq { get; set; }

    public int? PlayerSeq { get; set; }

    public decimal? PlayerPrice { get; set; }

    public string? PlayerTeam { get; set; }

    public int? TeamSeq { get; set; }

    public virtual Player? PlayerSeqNavigation { get; set; }

    public virtual Team? TeamSeqNavigation { get; set; }
}
