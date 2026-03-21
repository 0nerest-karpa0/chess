using Microsoft.VisualBasic;
using static System.Net.WebRequestMethods;

namespace Chess.Frontend.ChessLogic.Pieces
{
    public class King:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB3aWR0aD0iNDUiIGhlaWdodD0iNDUiPgogIDxnIGZpbGw9Im5vbmUiIGZpbGwtcnVsZT0iZXZlbm9kZCIgc3Ryb2tlPSIjMDAwIiBzdHJva2UtbGluZWNhcD0icm91bmQiIHN0cm9rZS1saW5lam9pbj0icm91bmQiIHN0cm9rZS13aWR0aD0iMS41Ij4KICAgIDxwYXRoIHN0cm9rZS1saW5lam9pbj0ibWl0ZXIiIGQ9Ik0yMi41IDExLjYzVjZNMjAgOGg1Ii8+CiAgICA8cGF0aCBmaWxsPSIjZmZmIiBzdHJva2UtbGluZWNhcD0iYnV0dCIgc3Ryb2tlLWxpbmVqb2luPSJtaXRlciIgZD0iTTIyLjUgMjVzNC41LTcuNSAzLTEwLjVjMCAwLTEtMi41LTMtMi41cy0zIDIuNS0zIDIuNWMtMS41IDMgMyAxMC41IDMgMTAuNSIvPgogICAgPHBhdGggZmlsbD0iI2ZmZiIgZD0iTTEyLjUgMzdjNS41IDMuNSAxNC41IDMuNSAyMCAwdi03czktNC41IDYtMTAuNWMtNC02LjUtMTMuNS0zLjUtMTYgNFYyN3YtMy41Yy0yLjUtNy41LTEyLTEwLjUtMTYtNC0zIDYgNiAxMC41IDYgMTAuNXY3Ii8+CiAgICA8cGF0aCBkPSJNMTIuNSAzMGM1LjUtMyAxNC41LTMgMjAgMG0tMjAgMy41YzUuNS0zIDE0LjUtMyAyMCAwbS0yMCAzLjVjNS41LTMgMTQuNS0zIDIwIDAiLz4KICA8L2c+Cjwvc3ZnPg==";
        public override string PieceImageUrlBlack { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB2ZXJzaW9uPSIxLjEiIHdpZHRoPSI0NSIgaGVpZ2h0PSI0NSI+CiAgPGcgc3R5bGU9ImZpbGw6bm9uZTsgZmlsbC1vcGFjaXR5OjE7IGZpbGwtcnVsZTpldmVub2RkOyBzdHJva2U6IzAwMDAwMDsgc3Ryb2tlLXdpZHRoOjEuNTsgc3Ryb2tlLWxpbmVjYXA6cm91bmQ7c3Ryb2tlLWxpbmVqb2luOnJvdW5kO3N0cm9rZS1taXRlcmxpbWl0OjQ7IHN0cm9rZS1kYXNoYXJyYXk6bm9uZTsgc3Ryb2tlLW9wYWNpdHk6MTsiPgogICAgPHBhdGggZD0iTSAyMi41LDExLjYzIEwgMjIuNSw2IiBzdHlsZT0iZmlsbDpub25lOyBzdHJva2U6IzAwMDAwMDsgc3Ryb2tlLWxpbmVqb2luOm1pdGVyOyIgaWQ9InBhdGg2NTcwIi8+CiAgICA8cGF0aCBkPSJNIDIyLjUsMjUgQyAyMi41LDI1IDI3LDE3LjUgMjUuNSwxNC41IEMgMjUuNSwxNC41IDI0LjUsMTIgMjIuNSwxMiBDIDIwLjUsMTIgMTkuNSwxNC41IDE5LjUsMTQuNSBDIDE4LDE3LjUgMjIuNSwyNSAyMi41LDI1IiBzdHlsZT0iZmlsbDojMDAwMDAwO2ZpbGwtb3BhY2l0eToxOyBzdHJva2UtbGluZWNhcDpidXR0OyBzdHJva2UtbGluZWpvaW46bWl0ZXI7Ii8+CiAgICA8cGF0aCBkPSJNIDEyLjUsMzcgQyAxOCw0MC41IDI3LDQwLjUgMzIuNSwzNyBMIDMyLjUsMzAgQyAzMi41LDMwIDQxLjUsMjUuNSAzOC41LDE5LjUgQyAzNC41LDEzIDI1LDE2IDIyLjUsMjMuNSBMIDIyLjUsMjcgTCAyMi41LDIzLjUgQyAyMCwxNiAxMC41LDEzIDYuNSwxOS41IEMgMy41LDI1LjUgMTIuNSwzMCAxMi41LDMwIEwgMTIuNSwzNyIgc3R5bGU9ImZpbGw6IzAwMDAwMDsgc3Ryb2tlOiMwMDAwMDA7Ii8+CiAgICA8cGF0aCBkPSJNIDIwLDggTCAyNSw4IiBzdHlsZT0iZmlsbDpub25lOyBzdHJva2U6IzAwMDAwMDsgc3Ryb2tlLWxpbmVqb2luOm1pdGVyOyIvPgogICAgPHBhdGggZD0iTSAzMiwyOS41IEMgMzIsMjkuNSA0MC41LDI1LjUgMzguMDMsMTkuODUgQyAzNC4xNSwxNCAyNSwxOCAyMi41LDI0LjUgTCAyMi41LDI2LjYgTCAyMi41LDI0LjUgQyAyMCwxOCAxMC44NSwxNCA2Ljk3LDE5Ljg1IEMgNC41LDI1LjUgMTMsMjkuNSAxMywyOS41IiBzdHlsZT0iZmlsbDpub25lOyBzdHJva2U6I2ZmZmZmZjsiLz4KICAgIDxwYXRoIGQ9Ik0gMTIuNSwzMCBDIDE4LDI3IDI3LDI3IDMyLjUsMzAgTSAxMi41LDMzLjUgQyAxOCwzMC41IDI3LDMwLjUgMzIuNSwzMy41IE0gMTIuNSwzNyBDIDE4LDM0IDI3LDM0IDMyLjUsMzciIHN0eWxlPSJmaWxsOm5vbmU7IHN0cm9rZTojZmZmZmZmOyIvPgogIDwvZz4KPC9zdmc+Cg==";
        public bool CanCastle { get; set; } = true;
        public King(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();
            List<ChessCoordinates> allPossibleMoves = new List<ChessCoordinates>
                { Position.ApplyOffset(-1,1), Position.ApplyOffset(0,1), Position.ApplyOffset(1,1),
                  Position.ApplyOffset(-1,0), Position.ApplyOffset(1,0),
                  Position.ApplyOffset(-1,-1), Position.ApplyOffset(0,-1), Position.ApplyOffset(1,-1)};

            foreach (ChessCoordinates move in allPossibleMoves)
            {
                if (!move.IsValidCoordinates)
                {
                    continue;
                }

                if ((pieces[move.ToPieceIndex()] != null && CanCapture(pieces[move.ToPieceIndex()])) || pieces[move.ToPieceIndex()] == null)
                {
                    moves.Add(new Move { newPosition = move, MarkAsNonCastling = !CanCastle });
                }
            }

            moves.AddRange(GetCastles(pieces));

            return moves.ToArray();
        }

        //public override string GetImageUrl()
        //{
        //    /*<a href="https://imgbb.com/"><img src="https://i.ibb.co/hx3qFgp2/kd-CANCST.png" alt="kd CANCST" border="0"></a>
        //    <a href="https://imgbb.com/"><img src="https://i.ibb.co/WNQX0bff/kw-CANCST.png" alt="kw CANCST" border="0"></a>*/

        //    if (!CanCastle)
        //    {
        //        return base.GetImageUrl();
        //    }
        //    else if (color == PieceColor.Black)
        //    {
        //        return "https://i.ibb.co/hx3qFgp2/kd-CANCST.png";
        //    }
        //    else
        //    {
        //        return "https://i.ibb.co/WNQX0bff/kw-CANCST.png";
        //    }
        //}

        public List<Move> GetCastles(Piece[] board)
        {
            if (!CanCastle) return new List<Move>();

            List<Move> castles = new List<Move>();
            Move? longCastle = GetCastle(board,  1);
            Move? shortCastle = GetCastle(board, -1);

            if (longCastle != null) castles.Add(longCastle);
            if (shortCastle != null) castles.Add(shortCastle);

            return castles;
        }

        private Move? GetCastle(Piece[] board, int direction)
        {
            int edge = direction == -1 ? 1 : Game.Columns;
            for (int i = Position.Letter + direction; i != edge; i += direction)
            {
                ChessCoordinates coordinates = new ChessCoordinates { Letter = i, Number = Position.Number };
                if (board[coordinates.ToPieceIndex()] != null)
                {
                    return null;
                }
            }

            ChessCoordinates rookCoordinates = new ChessCoordinates { Letter = edge, Number = Position.Number };
            int rookPieceIndex = rookCoordinates.ToPieceIndex();
            Piece? piece = board[rookPieceIndex];

            if (piece == null) return null;
            else if (piece.GetType() != typeof(Rook)) return null;
            else
            {
                Rook rook = (Rook)piece;
                if (!rook.CanCastle) return null;

                return new Move
                {
                    newPosition = new ChessCoordinates { Letter = 2 * direction + Position.Letter, Number = Position.Number },
                    CastlingRook = rook,
                    CastlingRookNewPosition = new ChessCoordinates { Letter = direction + Position.Letter, Number = Position.Number },
                    MarkAsNonCastling = false,
                };
            }
        }
    }
}
