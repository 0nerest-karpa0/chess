using Chess.Frontend.CustomElements;

namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Pawn:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB2ZXJzaW9uPSIxLjEiIHdpZHRoPSI0NSIgaGVpZ2h0PSI0NSI+CiAgPHBhdGggZD0ibSAyMi41LDkgYyAtMi4yMSwwIC00LDEuNzkgLTQsNCAwLDAuODkgMC4yOSwxLjcxIDAuNzgsMi4zOCBDIDE3LjMzLDE2LjUgMTYsMTguNTkgMTYsMjEgYyAwLDIuMDMgMC45NCwzLjg0IDIuNDEsNS4wMyBDIDE1LjQxLDI3LjA5IDExLDMxLjU4IDExLDM5LjUgSCAzNCBDIDM0LDMxLjU4IDI5LjU5LDI3LjA5IDI2LjU5LDI2LjAzIDI4LjA2LDI0Ljg0IDI5LDIzLjAzIDI5LDIxIDI5LDE4LjU5IDI3LjY3LDE2LjUgMjUuNzIsMTUuMzggMjYuMjEsMTQuNzEgMjYuNSwxMy44OSAyNi41LDEzIGMgMCwtMi4yMSAtMS43OSwtNCAtNCwtNCB6IiBzdHlsZT0ib3BhY2l0eToxOyBmaWxsOiNmZmZmZmY7IGZpbGwtb3BhY2l0eToxOyBmaWxsLXJ1bGU6bm9uemVybzsgc3Ryb2tlOiMwMDAwMDA7IHN0cm9rZS13aWR0aDoxLjU7IHN0cm9rZS1saW5lY2FwOnJvdW5kOyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IHN0cm9rZS1taXRlcmxpbWl0OjQ7IHN0cm9rZS1kYXNoYXJyYXk6bm9uZTsgc3Ryb2tlLW9wYWNpdHk6MTsiLz4KPC9zdmc+Cg==";
        public override string PieceImageUrlBlack { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB2ZXJzaW9uPSIxLjEiIHdpZHRoPSI0NSIgaGVpZ2h0PSI0NSI+CiAgPHBhdGggZD0ibSAyMi41LDkgYyAtMi4yMSwwIC00LDEuNzkgLTQsNCAwLDAuODkgMC4yOSwxLjcxIDAuNzgsMi4zOCBDIDE3LjMzLDE2LjUgMTYsMTguNTkgMTYsMjEgYyAwLDIuMDMgMC45NCwzLjg0IDIuNDEsNS4wMyBDIDE1LjQxLDI3LjA5IDExLDMxLjU4IDExLDM5LjUgSCAzNCBDIDM0LDMxLjU4IDI5LjU5LDI3LjA5IDI2LjU5LDI2LjAzIDI4LjA2LDI0Ljg0IDI5LDIzLjAzIDI5LDIxIDI5LDE4LjU5IDI3LjY3LDE2LjUgMjUuNzIsMTUuMzggMjYuMjEsMTQuNzEgMjYuNSwxMy44OSAyNi41LDEzIGMgMCwtMi4yMSAtMS43OSwtNCAtNCwtNCB6IiBzdHlsZT0ib3BhY2l0eToxOyBmaWxsOiMwMDAwMDA7IGZpbGwtb3BhY2l0eToxOyBmaWxsLXJ1bGU6bm9uemVybzsgc3Ryb2tlOiMwMDAwMDA7IHN0cm9rZS13aWR0aDoxLjU7IHN0cm9rZS1saW5lY2FwOnJvdW5kOyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IHN0cm9rZS1taXRlcmxpbWl0OjQ7IHN0cm9rZS1kYXNoYXJyYXk6bm9uZTsgc3Ryb2tlLW9wYWNpdHk6MTsiLz4KPC9zdmc+Cg==";
        public bool canBeTakenByEnPassant = false;
        public Pawn(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();
            
            int direction = GetMovingDirection();
            ChessCoordinates move = Position.ApplyOffset(0, direction);
            if (move.IsValidCoordinates && pieces[move.ToPieceIndex()] == null) 
            {
                moves.Add(new Move {newPosition = move, PopupParameters = GetPopupParameters(move) } ); 
            }

            ChessCoordinates firstSpecialMove = Position.ApplyOffset(0, 2 * direction);
            if (Position.Number == GetStartingRank() && pieces[firstSpecialMove.ToPieceIndex()] == null && moves.Count > 0)
            {
                moves.Add(new Move { newPosition = firstSpecialMove, CanBeTakenByEnPassant = true });
            }

            ChessCoordinates[] captureMoves = new ChessCoordinates[] { Position.ApplyOffset(-1, direction), Position.ApplyOffset(1, direction) };
            foreach(ChessCoordinates captureMove in captureMoves)
            {
                if(captureMove.IsValidCoordinates && CanCapture(pieces[captureMove.ToPieceIndex()]))
                {
                    moves.Add(new Move { newPosition = captureMove, PopupParameters = GetPopupParameters(captureMove) });
                }
            }

            ChessCoordinates[] enPassantMoves = new ChessCoordinates[] { Position.ApplyOffset(-1, 0), Position.ApplyOffset(1, 0) };
            foreach (ChessCoordinates enPassantMove in enPassantMoves)
            {
                Piece? piece = pieces[enPassantMove.ToPieceIndex()];
                if (piece == null) continue;
                if (piece.GetType() != typeof(Pawn)) continue;

                Pawn pawn = (Pawn)piece;
                if (enPassantMove.IsValidCoordinates && CanCapture(piece) && pawn.canBeTakenByEnPassant)
                {
                    moves.Add(new Move { newPosition = enPassantMove.ApplyOffset(0, direction), EnPassantPawn = pawn } );
                }
            }

            return moves.ToArray();
        }

        private int GetMovingDirection()
        {
            if (color == PieceColor.White) return 1;
            else return -1;
        }

        private int GetStartingRank()
        {
            if (color == PieceColor.White) return 2;
            else return 7;
        }

        private int GetPromotionRank()
        {
            if (color == PieceColor.White) return 8;
            else return 1;
        }

        public PromotionPopup.Parameters? GetPopupParameters(ChessCoordinates newPosition)
        {
            if (newPosition.Number != GetPromotionRank()) return null;

            PromotionPopup.Parameters parameters = PromotionPopup.Parameters.DefaultParameters();
            parameters.PieceColor = color;
            parameters.Visible = true;
            return parameters;
        }
    }
}
