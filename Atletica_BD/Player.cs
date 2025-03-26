namespace Atletica_BD
{
    public class Player : BaseEntity
    {
        //public string? Id { get; set; }
        public string? nick { get; set; }
        public Team? team { get; set; }// ? = Possível informação vazia
        public Guid teamId { get; set; }
        public int totalKills { get; set; }
        public int totalAssists { get; set; }
        public int totalDeaths { get; set; }
        public int totalMVP { get; set; }
        public double totalMinutes { get; set; }
        public int wins { get; set; }
        public int losses { get; set; }
        public int totalGold { get; set; }
        public int teamTotalGold { get; set; }
        public int teamTotalKill { get; set; }
        public int totalVisionScore { get; set; }
        public int totalFirstBlood { get; set; }
        public int totalTeamFirstBlood { get; set; }
    }

}
