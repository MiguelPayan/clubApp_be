namespace ClubApp.DTOs.Players
{
    public class AddingPlayersDTO
    {
        //This DTO is only used for poblating the database

        public string? PhotoSrc { get; set; }

        public string? Playername { get; set; }

        public int? Age { get; set; }

        public string? OriginalTeam { get; set; }

        public int? OverallRating { get; set; }

        public string? Potential { get; set; }

        public string? MarketValue { get; set; }

        public int? Shooting { get; set; }

        public int? Dribling { get; set; }

        public int? Pace { get; set; }

        public int? Strenght { get; set; }

        public int? Interceptions { get; set; }

        public int? DefensiveAwareness { get; set; }

        public int? Reflects { get; set; }

        public double? ReleaseClause { get; set; }

        public double? PositionX { get; set; }

        public double? PositionY { get; set; }

        public bool? IsStarting { get; set; }

    }
}
