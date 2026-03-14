namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Pawn:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/4/45/Chess_plt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/c/c7/Chess_pdt45.svg";
        public bool canBeTakenByEnPassant = false;
        public Pawn(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();
            
            int direction = GetMovingDirection();
            ChessCoordinates move = Position.ApplyOffset(0, direction);
            if (move.IsValidCoordinates && pieces[move.ToPieceIndex()] == null) 
            {
                moves.Add(new Move {newPosition = move }); 
            }

            ChessCoordinates firstSpecialMove = Position.ApplyOffset(0, 2 * direction);
            if (Position.Number == GetStartingRank() && pieces[firstSpecialMove.ToPieceIndex()] == null && moves.Count > 0)
            {
                moves.Add(new Move { newPosition = firstSpecialMove });
            }

            ChessCoordinates[] captureMoves = new ChessCoordinates[] { Position.ApplyOffset(-1, direction), Position.ApplyOffset(1, direction) };
            foreach(ChessCoordinates captureMove in captureMoves)
            {
                if(captureMove.IsValidCoordinates && CanCapture(pieces[captureMove.ToPieceIndex()]))
                {
                    moves.Add(new Move { newPosition = captureMove });
                }
            }

            ChessCoordinates[] enPassantMoves = new ChessCoordinates[] { Position.ApplyOffset(-1, 0), Position.ApplyOffset(1, 0) };
            foreach (ChessCoordinates enPassantMove in enPassantMoves)
            {
                Piece piece = pieces[enPassantMove.ToPieceIndex()];
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

        public int GetMovingDirection()
        {
            if (color == PieceColor.White) return 1;
            else return -1;
        }

        public int GetStartingRank()
        {
            if (color == PieceColor.White) return 2;
            else return 7;
        }

        public override string GetImageUrl()
        {
            if (!canBeTakenByEnPassant) return base.GetImageUrl();
            else
            {
                if(color == PieceColor.White)
                {
                    return "https://i.ibb.co/dwqfffxs/pw-EP.png";
                }
                else
                {
                    return "https://i.ibb.co/hxCRpByw/pd-EP.png";
                }
            }
        }
    }
}
