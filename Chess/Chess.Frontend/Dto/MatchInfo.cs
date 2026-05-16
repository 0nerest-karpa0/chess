namespace Chess.Frontend.Dto
{
    public class MatchInfo
    {
        public string? whiteLogin { get; set; }
        public string? blackLogin { get; set; }
        public bool isHost { get; set; }
        public bool canStartMatch { get; set; }
        public bool playerColor { get; set; }
        public bool isStarted { get; set; }
    }
}
