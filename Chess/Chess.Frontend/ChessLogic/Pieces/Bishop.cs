namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Bishop:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/b/b1/Chess_blt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/9/98/Chess_bdt45.svg";

        public Bishop(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();

            moves.AddRange(GetMovesLine(1, 1, pieces));
            moves.AddRange(GetMovesLine(-1, 1, pieces));
            moves.AddRange(GetMovesLine(1, -1, pieces));
            moves.AddRange(GetMovesLine(-1, -1, pieces));

            return moves.ToArray();
        }
    }
}
