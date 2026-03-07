namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Bishop:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/b/b1/Chess_blt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/9/98/Chess_bdt45.svg";

        public Bishop(PieceColor color) : base(color) { }

        public override ChessCoordinates[] GetMoves(Piece?[] pieces)
        {
            List<ChessCoordinates> moves = new List<ChessCoordinates>();

            for (int i = 0; ; i--)
            {
                ChessCoordinates move = new ChessCoordinates { Letter = Position.Letter + i, Number = Position.Number };

                if (pieces[move.ToPieceIndex()] == null)
                {
                    moves.Add(move);
                }
                else if (CanCapture(pieces[move.ToPieceIndex()]))
                {
                    moves.Add(move);
                    break;
                }
                else
                {
                    break;
                }
            }

            return moves.ToArray();
        }
    }
}
