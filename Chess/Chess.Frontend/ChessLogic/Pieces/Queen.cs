namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Queen:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/1/15/Chess_qlt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/4/47/Chess_qdt45.svg";

        public Queen(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();

            moves.AddRange(GetMovesLine(0, 1, pieces));
            moves.AddRange(GetMovesLine(0, -1, pieces));
            moves.AddRange(GetMovesLine(1, 0, pieces));
            moves.AddRange(GetMovesLine(-1, 0, pieces));

            moves.AddRange(GetMovesLine(1, 1, pieces));
            moves.AddRange(GetMovesLine(-1, 1, pieces));
            moves.AddRange(GetMovesLine(1, -1, pieces));
            moves.AddRange(GetMovesLine(-1, -1, pieces));

            return moves.ToArray();
        }
    }
}
