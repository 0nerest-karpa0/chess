namespace Chess.Backend.Dto
{
    public class MoveDto
    {
        public string Board { get; set; }
        public bool IsCheckmate { get; set; }
        public bool IsDraw { get; set; }
    }
}
