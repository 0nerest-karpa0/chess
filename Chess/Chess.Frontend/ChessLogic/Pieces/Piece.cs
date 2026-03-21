using Chess.Frontend.CustomElements;

namespace Chess.Frontend.ChessLogic.Pieces
{
    public abstract class Piece
    {
        public ChessCoordinates Position { get; set; }
        public abstract string PieceImageUrlWhite { get; set; }
        public abstract string PieceImageUrlBlack { get; set; }

        protected PieceColor color;
        public Piece(PieceColor color)
        {
            this.color = color;
        }

        public virtual string GetImageUrl()
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

        protected Move[] GetMovesLine(int letterIncrease, int numberIncrease, Piece?[] board)
        {
            List<Move> moves = new List<Move>();

            for (int i = 1; ; i++)
            {
                ChessCoordinates move = new ChessCoordinates
                {
                    Letter = Position.Letter + i * letterIncrease,
                    Number = Position.Number + i * numberIncrease
                };
                if (!move.IsValidCoordinates) break;
                bool needToBreak = false;
                if (CanMoveHere(board, move, out needToBreak))
                {
                    moves.Add(new Move { newPosition = move});
                }

                if (needToBreak) break;
            }

            return moves.ToArray();
        }

        protected Move[] GetMovesLine(int letterIncrease, int numberIncrease, Piece?[] board, Move moveParameters)
        {
            List<Move> moves = new List<Move>();

            for (int i = 1; ; i++)
            {
                ChessCoordinates move = new ChessCoordinates
                {
                    Letter = Position.Letter + i * letterIncrease,
                    Number = Position.Number + i * numberIncrease,
                };
                if (!move.IsValidCoordinates) break;
                bool needToBreak = false;
                if (CanMoveHere(board, move, out needToBreak))
                {
                    moves.Add(new Move
                    {
                        newPosition = move,
                        CanBeTakenByEnPassant = moveParameters.CanBeTakenByEnPassant, 
                        EnPassantPawn = moveParameters.EnPassantPawn,
                        MarkAsNonCastling = moveParameters.MarkAsNonCastling,
                        CastlingRook = moveParameters.CastlingRook,
                        CastlingRookNewPosition = moveParameters.CastlingRookNewPosition,
                        PopupParameters = moveParameters.PopupParameters
                    });
                }

                if (needToBreak) break;
            }

            return moves.ToArray();
        }

        protected bool CanCapture(Piece? enemyPiece)
        {
            if (enemyPiece != null)
            {
                return enemyPiece.color != color;
            }

            return false;
        }

        protected bool CanMoveHere(Piece?[] board, ChessCoordinates move, out bool needToBreak)
        {
            needToBreak = false;
            if (board[move.ToPieceIndex()] == null)
            {
                return true;
            }
            else if (CanCapture(board[move.ToPieceIndex()]))
            {
                needToBreak = true;
                return true;
            }
            else
            {
                needToBreak = true;
                return false;
            }
        }

        public abstract Move[] GetMoves(Piece?[] pieces);
    }
}

public enum PieceColor
{
    White,
    Black,
}