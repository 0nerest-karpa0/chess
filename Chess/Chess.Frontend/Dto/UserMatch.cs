namespace Chess.Frontend.Dto
{
    public class UserMatch
    {
        public Guid id { get; set; }
        //white -- false, black -- true
        public bool usersColor { get; set; }
        public string? lastMoveBoard { get; set; }
        public UserShortDto? black { get; set; }
        public UserShortDto? white { get; set; }
        public bool isStarted { get; set; }
        public bool isEnded { get; set; }
    }

    public class UserShortDto
    {
        public Guid id { get; set; }
        public string login { get; set; }
    }
}
