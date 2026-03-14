using Chess.Frontend.ChessLogic.Pieces;

namespace Chess.Frontend.ChessLogic
{
    public class Move
    {
        public required ChessCoordinates newPosition { get; set; }
        public Piece? EnPassantPawn { get; set; } = null;
        public Piece? CastlingRook { get; set; } = null;
        public ChessCoordinates? CastlingRookNewPosition { get; set; } = null;
    }
}
