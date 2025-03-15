namespace IPL.Common.Models
{
    public class Player
    {
        public int PlayerSeq { get; set; }

        public string? PlayerName { get; set; }

        public int? JerseyNo { get; set; }

        public string? Country { get; set; }

        public string? IsForeignPlayer { get; set; } 

        public decimal? RecorVersion { get; set; }
    }
}
