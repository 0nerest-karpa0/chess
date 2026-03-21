using Chess.Frontend.ChessLogic.Pieces;
using Chess.Frontend.CustomElements;
using System.Drawing;

namespace Chess.Frontend.ChessLogic
{
    public class Game
    {
        public const int Rows = 8;
        public const int Columns = 8;
        public const int CellCount = Rows * Columns;
        private string BoardSize = "max(35vw, 35vh)";
        public Piece?[] Board { get; set; } = GetBoardFromFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR w KQkq - 1 2");
        public Move?[] CellMoves { get; set; } = new Move?[CellCount];
        public Piece? SelectedPiece { get; set; } = null;
        public PromotionPopup.Parameters PopupParameters { get; set; } = PromotionPopup.Parameters.DefaultParameters();
        private Pawn? EnPassantPawn = null;
        public event Action UpdateBoard;
        public static Piece?[] GetBoardFromFen(string fenString)
        {
            Piece?[] board = new Piece?[CellCount];

            int boardIndex = 0;
            for(int i = 0; boardIndex < CellCount; i++, boardIndex++)
            {
                if (char.IsDigit(fenString[i]))
                {
                    boardIndex += Convert.ToInt32($"{fenString[i]}") - 1;
                }
                else
                {
                    switch (fenString[i])
                    {
                        case '/':
                            boardIndex--;
                            continue;
                        case ' ':
                            break;
                        default:
                            board[boardIndex] = GetPieceFromFen(fenString[i]);
                            board[boardIndex].Position = ChessCoordinates.FromPieceIndex(boardIndex);
                            break;
                    }
                }
            }

            return board;
        }

        public static Piece? GetPieceFromFen(char piece)
        {
            PieceColor color = PieceColor.Black;
            if (char.IsUpper(piece)) 
            {
                color = PieceColor.White;
            }
            piece = char.ToLower(piece);

            switch (piece) 
            {
                case 'p':
                    return new Pawn(color);
                case 'r':
                    return new Rook(color);
                case 'n':
                    return new Knight(color);
                case 'k':
                    return new King(color);
                case 'q':
                    return new Queen(color);
                case 'b':
                    return new Bishop(color);
                default:
                    return null;
            }
        }

        public void SelectCells(Move[] moves)
        {
            CellMoves = new Move?[CellCount];
            foreach (Move move in moves)
            {
                int pieceIndex = move.newPosition.ToPieceIndex();
                CellMoves[pieceIndex] = move;
            }
            UpdateBoard.Invoke();
        }

        public void DeselectCells()
        {
            CellMoves = new Move?[CellCount];
            UpdateBoard.Invoke();
        }

        public void MovePiece(Move move)
        {
            if (SelectedPiece == null) return;
            ChessCoordinates newPosition = move.newPosition;

            MarkEnPassantPossibility(move);
            ChessCoordinates oldPosition = SelectedPiece.Position;
            int oldPieceIndex = oldPosition.ToPieceIndex();
            int newPieceIndex = newPosition.ToPieceIndex();

            SelectedPiece.Position = newPosition;

            Board[oldPieceIndex] = null;
            Board[newPieceIndex] = SelectedPiece;

            if (move.PopupParameters != null)
            {
                move.PopupParameters.MarginLeft = $"calc({BoardSize} + 5px)";
                //move.PopupParameters.MarginTop = $"calc({BoardSize} / {Rows} * abs({newPosition.Number - Rows}) + 7px)";
                move.PopupParameters.MarginTop = $"7px";
                PopupParameters = move.PopupParameters;
                DeselectCells();
                UpdateBoard.Invoke();
                return;
            }
            else if (move.EnPassantPawn != null)
            {
                Board[move.EnPassantPawn.Position.ToPieceIndex()] = null;
            }
            else if (!move.MarkAsNonCastling)
            {
                MarkAsNonCastling();
            }
            
            if (move.CastlingRook != null)
            {
                Castle(move);
            }

            DeselectCells();
            UpdateBoard.Invoke();
        }

        //TODO: while the popup is visible you can switch to the different piece and promote it
        public void PromotePawn(Piece piece)
        {
            PopupParameters.Visible = false;

            ChessCoordinates pawnPosition = SelectedPiece.Position;
            piece.Position = pawnPosition;
            Board[pawnPosition.ToPieceIndex()] = piece;

            UpdateBoard.Invoke();
        }

        private void MarkEnPassantPossibility(Move move)
        {
            if (EnPassantPawn != null)
            {
                EnPassantPawn.canBeTakenByEnPassant = false;
            }

            if (move.CanBeTakenByEnPassant)
            {
                Pawn pawn = (Pawn)SelectedPiece;
                pawn.canBeTakenByEnPassant = true;
                EnPassantPawn = pawn;
            }
        }

        private void MarkAsNonCastling()
        {
            if (SelectedPiece.GetType() == typeof(Rook))
            {
                Rook rook = (Rook)SelectedPiece;
                rook.CanCastle = false;
            }
            else if(SelectedPiece.GetType() == typeof(King))
            {
                King rook = (King)SelectedPiece;
                rook.CanCastle = false;
            }
        }
        private void Castle(Move move)
        {
            ChessCoordinates oldPosition = move.CastlingRook.Position;
            ChessCoordinates newPosition = move.CastlingRookNewPosition;

            Board[oldPosition.ToPieceIndex()] = null;
            Board[newPosition.ToPieceIndex()] = move.CastlingRook;
            move.CastlingRook.Position = newPosition;
            move.CastlingRook.CanCastle = false;
        }
    }
}
