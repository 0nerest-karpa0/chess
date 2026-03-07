namespace Chess.Frontend.ChessLogic.Pieces
{
    public abstract class Piece
    {
        public ChessCoordinates Position { get; set; }
        public abstract string PieceImageUrlWhite { get; set; }
        public abstract string PieceImageUrlBlack { get; set; }

        private PieceColor color;
        public Piece(PieceColor color)
        {
            this.color = color;
        }

        public string GetImageUrl()
        {
            if (color == PieceColor.White) return PieceImageUrlWhite;
            else return PieceImageUrlBlack;
        }

        public Piece GetInvertedColorPiece()
        {
            Piece inverted = (Piece)MemberwiseClone();
            inverted.color = PieceColor.White;
            return inverted;
        }

        protected bool CanCapture(Piece? enemyPiece)
        {
            if(enemyPiece != null)
            {
                return enemyPiece.color != color;
            }

            return false;
        }

        public abstract ChessCoordinates[] GetMoves(Piece?[] pieces);
    }
}

public enum PieceColor
{
    White,
    Black,
}