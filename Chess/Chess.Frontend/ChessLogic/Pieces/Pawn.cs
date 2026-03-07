namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Pawn:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/4/45/Chess_plt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/c/c7/Chess_pdt45.svg";

        public Pawn(PieceColor color) : base(color) { }

        public override ChessCoordinates[] GetMoves(Piece?[] pieces)
        {
            List<ChessCoordinates> moves = new List<ChessCoordinates>();

            ChessCoordinates move = Position.ApplyOffset(0, 1);
            if (move.IsValidCoordinates && pieces[move.ToPieceIndex()] == null) 
            {
                moves.Add(move); 
            }

            ChessCoordinates[] captureMoves = new ChessCoordinates[] { Position.ApplyOffset(-1, 1), Position.ApplyOffset(1, 1) };

            foreach(ChessCoordinates captureMove in captureMoves)
            {
                if(captureMove.IsValidCoordinates && CanCapture(pieces[captureMove.ToPieceIndex()]))
                {
                    moves.Add(captureMove);
                }
            }

            return moves.ToArray();
        }
    }
}
