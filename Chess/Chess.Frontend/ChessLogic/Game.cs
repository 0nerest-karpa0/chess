using Chess.Frontend.ChessLogic.Pieces;
using Chess.Frontend.CustomElements;

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

        public void SelectCells(ChessCoordinates[] cells)
        {
            IsCellSelected = new bool[CellCount];
            foreach (ChessCoordinates cell in cells)
            {
                IsCellSelected[cell.ToPieceIndex()] = true;
            }
            UpdateBoard.Invoke();
        }

        public void MovePiece(ChessCoordinates newPosition)
        {
            if (SelectedPiece == null) return;
            int oldPieceIndex = SelectedPiece.Position.ToPieceIndex();
            int newPieceIndex = newPosition.ToPieceIndex();

            SelectedPiece.Position = newPosition;

            Board[oldPieceIndex] = null;
            Board[newPieceIndex] = SelectedPiece;

            IsCellSelected = new bool[CellCount];
            SelectedPiece = null;

            UpdateBoard.Invoke();
        }
    }
}
