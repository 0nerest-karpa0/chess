namespace Chess.Frontend.ChessLogic.Pieces
{
    public class King:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/4/42/Chess_klt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/f/f0/Chess_kdt45.svg";

        public King(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();
            List<ChessCoordinates> allPossibleMoves = new List<ChessCoordinates>
                { Position.ApplyOffset(-1,1), Position.ApplyOffset(0,1), Position.ApplyOffset(1,1),
                  Position.ApplyOffset(-1,0), Position.ApplyOffset(1,0),
                  Position.ApplyOffset(-1,-1), Position.ApplyOffset(0,-1), Position.ApplyOffset(1,-1)};

            foreach (ChessCoordinates move in allPossibleMoves)
            {
                if (!move.IsValidCoordinates)
                {
                    continue;
                }

                if ((pieces[move.ToPieceIndex()] != null && CanCapture(pieces[move.ToPieceIndex()])) || pieces[move.ToPieceIndex()] == null)
                {
                    moves.Add(new Move { newPosition = move });
                }
            }
            return moves.ToArray();
        }
    }
}
