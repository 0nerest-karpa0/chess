namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Queen:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/1/15/Chess_qlt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/4/47/Chess_qdt45.svg";

        public Queen(PieceColor color) : base(color) { }

        public override ChessCoordinates[] GetMoves(Piece?[] pieces)
        {
            throw new NotImplementedException();
        }
    }
}
