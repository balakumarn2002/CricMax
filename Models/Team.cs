using System;
using System.Collections.Generic;

namespace IPL.Models;

public partial class Team
{
    public int TeamSeq { get; set; }

    public string? TeamName { get; set; }

    public int? NoOfPlayers { get; set; }

    public string? TeamSponsor { get; set; }

    public string? TeamStadium { get; set; }

    public int? NoOfTrophy { get; set; }

    public int? IplSeq { get; set; }

    public decimal? CreatedBySeq { get; set; }

    public DateTime? CreatedByDtTm { get; set; }

    public decimal? ModifiedBySeq { get; set; }

    public DateTime? ModifiedDtTm { get; set; }

    public byte[] RecorVer { get; set; } = null!;

    public virtual Ipl? IplSeqNavigation { get; set; }

    public virtual ICollection<PlayerPurchase> PlayerPurchases { get; set; } = new List<PlayerPurchase>();
}
