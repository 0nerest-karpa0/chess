namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Knight:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/7/70/Chess_nlt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/e/ef/Chess_ndt45.svg";

        public Knight(PieceColor color) : base(color) { }

        public override ChessCoordinates[] GetMoves(Piece?[] pieces)
        {
           List<ChessCoordinates> moves = new List<ChessCoordinates>();
           List <ChessCoordinates> allPossibleMoves = new List<ChessCoordinates>
                { Position.ApplyOffset(2, -1),    Position.ApplyOffset(2, 1), 
                    Position.ApplyOffset(-2, -1), Position.ApplyOffset(-2, 1),
                    Position.ApplyOffset(1, 2),   Position.ApplyOffset(1, -2),
                    Position.ApplyOffset(-1, 2),  Position.ApplyOffset(-1, -2) };

            foreach(ChessCoordinates move in allPossibleMoves)
            {
                if (!move.IsValidCoordinates)
                {
                    continue;
                }

                if ( (pieces[move.ToPieceIndex()] != null && CanCapture(pieces[move.ToPieceIndex()])) || pieces[move.ToPieceIndex()] == null )
                {
                    moves.Add(move);
                }
            }
            return moves.ToArray();
        }
    }
}
