 namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Rook:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/7/72/Chess_rlt45.svg";
        public override string PieceImageUrlBlack { get; set; } = "https://upload.wikimedia.org/wikipedia/commons/f/ff/Chess_rdt45.svg";

        public Rook(PieceColor color) : base(color) { }

        public override ChessCoordinates[] GetMoves(Piece?[] pieces)
        {
            List<ChessCoordinates> moves = new List<ChessCoordinates>();
            for (int i = Position.Letter - 1; i > 0; i--) 
            {
                ChessCoordinates move = new ChessCoordinates { Letter = i, Number = Position.Number };
                bool needToBreak = false;
                if(CanMoveHere(pieces, move, out needToBreak))
                {
                    moves.Add(move);
                }

                if (needToBreak) break;
            }

            for (int i = Position.Letter + 1; i <= Game.Rows; i++)
            {
                ChessCoordinates move = new ChessCoordinates { Letter = i, Number = Position.Number };
                bool needToBreak = false;
                if (CanMoveHere(pieces, move, out needToBreak))
                {
                    moves.Add(move);
                }

                if (needToBreak) break;
            }

            for (int i = Position.Number + 1; i <= Game.Columns; i++)
            {
                ChessCoordinates move = new ChessCoordinates { Letter = Position.Letter, Number = i };
                bool needToBreak = false;
                if (CanMoveHere(pieces, move, out needToBreak))
                {
                    moves.Add(move);
                }

                if (needToBreak) break;
            }

            for (int i = Position.Number - 1; i > 0; i--)
            {
                ChessCoordinates move = new ChessCoordinates { Letter = Position.Letter, Number = i };
                bool needToBreak = false;
                if (CanMoveHere(pieces, move, out needToBreak))
                {
                    moves.Add(move);
                }

                if (needToBreak) break;
            }

            return moves.ToArray();
        }

        private bool CanMoveHere(Piece?[] board, ChessCoordinates move, out bool needToBreak)
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
                return true;
            }
        }
    }
}
