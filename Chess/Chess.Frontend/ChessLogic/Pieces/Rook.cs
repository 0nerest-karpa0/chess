 namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Rook:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+DQo8IURPQ1RZUEUgc3ZnIFBVQkxJQyAiLS8vVzNDLy9EVEQgU1ZHIDEuMS8vRU4iICJodHRwOi8vd3d3LnczLm9yZy9HcmFwaGljcy9TVkcvMS4xL0RURC9zdmcxMS5kdGQiPg0KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZlcnNpb249IjEuMSIgd2lkdGg9IjQ1IiBoZWlnaHQ9IjQ1Ij4NCiAgPGcgc3R5bGU9Im9wYWNpdHk6MTsgZmlsbDojZmZmZmZmOyBmaWxsLW9wYWNpdHk6MTsgZmlsbC1ydWxlOmV2ZW5vZGQ7IHN0cm9rZTojMDAwMDAwOyBzdHJva2Utd2lkdGg6MS41OyBzdHJva2UtbGluZWNhcDpyb3VuZDtzdHJva2UtbGluZWpvaW46cm91bmQ7c3Ryb2tlLW1pdGVybGltaXQ6NDsgc3Ryb2tlLWRhc2hhcnJheTpub25lOyBzdHJva2Utb3BhY2l0eToxOyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCwwLjMpIj4NCiAgICA8cGF0aA0KICAgICAgZD0iTSA5LDM5IEwgMzYsMzkgTCAzNiwzNiBMIDksMzYgTCA5LDM5IHogIg0KICAgICAgc3R5bGU9InN0cm9rZS1saW5lY2FwOmJ1dHQ7IiAvPg0KICAgIDxwYXRoDQogICAgICBkPSJNIDEyLDM2IEwgMTIsMzIgTCAzMywzMiBMIDMzLDM2IEwgMTIsMzYgeiAiDQogICAgICBzdHlsZT0ic3Ryb2tlLWxpbmVjYXA6YnV0dDsiIC8+DQogICAgPHBhdGgNCiAgICAgIGQ9Ik0gMTEsMTQgTCAxMSw5IEwgMTUsOSBMIDE1LDExIEwgMjAsMTEgTCAyMCw5IEwgMjUsOSBMIDI1LDExIEwgMzAsMTEgTCAzMCw5IEwgMzQsOSBMIDM0LDE0Ig0KICAgICAgc3R5bGU9InN0cm9rZS1saW5lY2FwOmJ1dHQ7IiAvPg0KICAgIDxwYXRoDQogICAgICBkPSJNIDM0LDE0IEwgMzEsMTcgTCAxNCwxNyBMIDExLDE0IiAvPg0KICAgIDxwYXRoDQogICAgICBkPSJNIDMxLDE3IEwgMzEsMjkuNSBMIDE0LDI5LjUgTCAxNCwxNyINCiAgICAgIHN0eWxlPSJzdHJva2UtbGluZWNhcDpidXR0OyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IiAvPg0KICAgIDxwYXRoDQogICAgICBkPSJNIDMxLDI5LjUgTCAzMi41LDMyIEwgMTIuNSwzMiBMIDE0LDI5LjUiIC8+DQogICAgPHBhdGgNCiAgICAgIGQ9Ik0gMTEsMTQgTCAzNCwxNCINCiAgICAgIHN0eWxlPSJmaWxsOm5vbmU7IHN0cm9rZTojMDAwMDAwOyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IiAvPg0KICA8L2c+DQo8L3N2Zz4NCg==";
        public override string PieceImageUrlBlack { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+CjwhRE9DVFlQRSBzdmcgUFVCTElDICItLy9XM0MvL0RURCBTVkcgMS4xLy9FTiIgImh0dHA6Ly93d3cudzMub3JnL0dyYXBoaWNzL1NWRy8xLjEvRFREL3N2ZzExLmR0ZCI+CjxzdmcgeG1sbnM9Imh0dHA6Ly93d3cudzMub3JnLzIwMDAvc3ZnIiB2ZXJzaW9uPSIxLjEiIHdpZHRoPSI0NSIgaGVpZ2h0PSI0NSI+CiAgPGcgc3R5bGU9Im9wYWNpdHk6MTsgZmlsbDojMDAwMDAwOyBmaWxsLW9wYWNpdHk6MTsgZmlsbC1ydWxlOmV2ZW5vZGQ7IHN0cm9rZTojMDAwMDAwOyBzdHJva2Utd2lkdGg6MS41OyBzdHJva2UtbGluZWNhcDpyb3VuZDtzdHJva2UtbGluZWpvaW46cm91bmQ7c3Ryb2tlLW1pdGVybGltaXQ6NDsgc3Ryb2tlLWRhc2hhcnJheTpub25lOyBzdHJva2Utb3BhY2l0eToxOyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCwwLjMpIj4KICAgIDxwYXRoCiAgICAgIGQ9Ik0gOSwzOSBMIDM2LDM5IEwgMzYsMzYgTCA5LDM2IEwgOSwzOSB6ICIKICAgICAgc3R5bGU9InN0cm9rZS1saW5lY2FwOmJ1dHQ7IiAvPgogICAgPHBhdGgKICAgICAgZD0iTSAxMi41LDMyIEwgMTQsMjkuNSBMIDMxLDI5LjUgTCAzMi41LDMyIEwgMTIuNSwzMiB6ICIKICAgICAgc3R5bGU9InN0cm9rZS1saW5lY2FwOmJ1dHQ7IiAvPgogICAgPHBhdGgKICAgICAgZD0iTSAxMiwzNiBMIDEyLDMyIEwgMzMsMzIgTCAzMywzNiBMIDEyLDM2IHogIgogICAgICBzdHlsZT0ic3Ryb2tlLWxpbmVjYXA6YnV0dDsiIC8+CiAgICA8cGF0aAogICAgICBkPSJNIDE0LDI5LjUgTCAxNCwxNi41IEwgMzEsMTYuNSBMIDMxLDI5LjUgTCAxNCwyOS41IHogIgogICAgICBzdHlsZT0ic3Ryb2tlLWxpbmVjYXA6YnV0dDtzdHJva2UtbGluZWpvaW46bWl0ZXI7IiAvPgogICAgPHBhdGgKICAgICAgZD0iTSAxNCwxNi41IEwgMTEsMTQgTCAzNCwxNCBMIDMxLDE2LjUgTCAxNCwxNi41IHogIgogICAgICBzdHlsZT0ic3Ryb2tlLWxpbmVjYXA6YnV0dDsiIC8+CiAgICA8cGF0aAogICAgICBkPSJNIDExLDE0IEwgMTEsOSBMIDE1LDkgTCAxNSwxMSBMIDIwLDExIEwgMjAsOSBMIDI1LDkgTCAyNSwxMSBMIDMwLDExIEwgMzAsOSBMIDM0LDkgTCAzNCwxNCBMIDExLDE0IHogIgogICAgICBzdHlsZT0ic3Ryb2tlLWxpbmVjYXA6YnV0dDsiIC8+CiAgICA8cGF0aAogICAgICBkPSJNIDEyLDM1LjUgTCAzMywzNS41IEwgMzMsMzUuNSIKICAgICAgc3R5bGU9ImZpbGw6bm9uZTsgc3Ryb2tlOiNmZmZmZmY7IHN0cm9rZS13aWR0aDoxOyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IiAvPgogICAgPHBhdGgKICAgICAgZD0iTSAxMywzMS41IEwgMzIsMzEuNSIKICAgICAgc3R5bGU9ImZpbGw6bm9uZTsgc3Ryb2tlOiNmZmZmZmY7IHN0cm9rZS13aWR0aDoxOyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IiAvPgogICAgPHBhdGgKICAgICAgZD0iTSAxNCwyOS41IEwgMzEsMjkuNSIKICAgICAgc3R5bGU9ImZpbGw6bm9uZTsgc3Ryb2tlOiNmZmZmZmY7IHN0cm9rZS13aWR0aDoxOyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IiAvPgogICAgPHBhdGgKICAgICAgZD0iTSAxNCwxNi41IEwgMzEsMTYuNSIKICAgICAgc3R5bGU9ImZpbGw6bm9uZTsgc3Ryb2tlOiNmZmZmZmY7IHN0cm9rZS13aWR0aDoxOyBzdHJva2UtbGluZWpvaW46bWl0ZXI7IiAvPgogICAgPHBhdGgKICAgICAgZD0iTSAxMSwxNCBMIDM0LDE0IgogICAgICBzdHlsZT0iZmlsbDpub25lOyBzdHJva2U6I2ZmZmZmZjsgc3Ryb2tlLXdpZHRoOjE7IHN0cm9rZS1saW5lam9pbjptaXRlcjsiIC8+CiAgPC9nPgo8L3N2Zz4K";
        public bool CanCastle { get; set; } = true;
        public Rook(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
            List<Move> moves = new List<Move>();
            Move moveParameters = new Move { newPosition = ChessCoordinates.Invalid, MarkAsNonCastling = !CanCastle };
            moves.AddRange(GetMovesLine( 0,  1, pieces, moveParameters));
            moves.AddRange(GetMovesLine( 0, -1, pieces, moveParameters));
            moves.AddRange(GetMovesLine( 1,  0, pieces, moveParameters));
            moves.AddRange(GetMovesLine(-1,  0, pieces, moveParameters));

            return moves.ToArray();
        }

       // public override string GetImageUrl()
       // {
       //     /*<a href="https://imgbb.com/"><img src="https://i.ibb.co/QjxV6xpc/rd-CANCST.png" alt="rd CANCST" border="0"></a>
       //< a href = "https://imgbb.com/" >< img src = "https://i.ibb.co/TB9rTqSX/rw-CANCST.png" alt = "rw CANCST" border = "0" ></ a > */
       //     if (!CanCastle)
       //     {
       //         return base.GetImageUrl();
       //     }
       //     else if (color == PieceColor.Black)
       //     {
       //         return "https://i.ibb.co/QjxV6xpc/rd-CANCST.png";
       //     }
       //     else
       //     {
       //         return "https://i.ibb.co/TB9rTqSX/rw-CANCST.png";
       //     }
       // }
    }
}
