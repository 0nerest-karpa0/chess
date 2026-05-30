namespace Chess.Frontend.Dto
{
    public class MoveDto
    {
        public string board { get; set; }
        public bool isCheckmate { get; set; }
        public bool isDraw { get; set; }
    }
}
