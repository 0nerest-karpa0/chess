using Chess.Frontend.ChessLogic.Pieces;
using Chess.Frontend.CustomElements;

namespace Chess.Frontend.ChessLogic
{
    public class Move
    {
        public required ChessCoordinates newPosition { get; set; }
        public bool CanBeTakenByEnPassant { get; set; } = false;
        public Piece? EnPassantPawn { get; set; } = null;
        public bool MarkAsNonCastling { get; set; } = true;
        public Rook? CastlingRook { get; set; } = null;
        public ChessCoordinates? CastlingRookNewPosition { get; set; } = null;
        public PromotionPopup.Parameters? PopupParameters { get; set; } = null;
    }
}
