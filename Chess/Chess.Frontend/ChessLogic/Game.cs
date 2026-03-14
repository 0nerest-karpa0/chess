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
        public Piece?[] Board { get; set; } = GetBoardFromFen("rnbqkbnr/pppppppp/8/8/8/8/PPPPPPPP/RNBQKBNR b KQkq - 1 2");
        public bool[] IsCellSelected { get; set; } = new bool[CellCount];
        public Piece? SelectedPiece { get; set; }
        private Pawn? EnPassantPawn = null;
        private Move[] moves;
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
            IsCellSelected = new bool[CellCount];
            foreach (Move move in moves)
            {
                IsCellSelected[move.newPosition.ToPieceIndex()] = true;
            }
            UpdateBoard.Invoke();

            this.moves = moves;
        }

        public void MovePiece(ChessCoordinates newPosition)
        {
            if (SelectedPiece == null) return;
            MarkEnPassantPossibility(newPosition);
            int oldPieceIndex = SelectedPiece.Position.ToPieceIndex();
            int newPieceIndex = newPosition.ToPieceIndex();

            SelectedPiece.Position = newPosition;

            Board[oldPieceIndex] = null;
            Board[newPieceIndex] = SelectedPiece;

            IsCellSelected = new bool[CellCount];
            SelectedPiece = null;

            Move move = FoundMove(newPosition);
            if (move.EnPassantPawn != null)
            {
                Board[move.EnPassantPawn.Position.ToPieceIndex()] = null;
            }

            UpdateBoard.Invoke();
        }

        public void MarkEnPassantPossibility(ChessCoordinates newPosition)
        {
            if (EnPassantPawn != null)
            {
                EnPassantPawn.canBeTakenByEnPassant = false;
            }
            if (SelectedPiece == null) return;
            if (SelectedPiece.GetType() != typeof(Pawn)) return;

            Pawn pawn = (Pawn)SelectedPiece;
            pawn.canBeTakenByEnPassant = pawn.GetStartingRank() + 2 * pawn.GetMovingDirection() == newPosition.Number && pawn.Position.Number == pawn.GetStartingRank();
            EnPassantPawn = pawn;
        }

        public Move FoundMove(ChessCoordinates newPosition)
        {
            foreach (Move move in moves)
            {
                if(move.newPosition.Equals(newPosition)) return move;
            }

            return null;
        }
    }
}
