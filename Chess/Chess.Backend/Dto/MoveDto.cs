namespace Chess.Backend.Dto
{
    public class MoveDto
    {
        public string Board { get; internal set; }
        public bool IsCheckmate { get; internal set; }
        public bool IsDraw { get; internal set; }
    }
}
