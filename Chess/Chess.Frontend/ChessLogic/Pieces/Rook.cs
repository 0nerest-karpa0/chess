 namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Rook:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/7/72/Chess_rlt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/f/ff/Chess_rdt45.svg";

        public Rook(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();

            moves.AddRange(GetMovesLine(0, 1, pieces));
            moves.AddRange(GetMovesLine(0, -1, pieces));
            moves.AddRange(GetMovesLine(1, 0, pieces));
            moves.AddRange(GetMovesLine(-1, 0, pieces));

            return moves.ToArray();
        }
    }
}
