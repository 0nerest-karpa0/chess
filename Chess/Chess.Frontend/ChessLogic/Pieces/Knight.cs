namespace Chess.Frontend.ChessLogic.Pieces
{
    public class Knight:Piece
    {
        public override string PieceImageUrlWhite { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+DQo8IURPQ1RZUEUgc3ZnIFBVQkxJQyAiLS8vVzNDLy9EVEQgU1ZHIDEuMS8vRU4iICJodHRwOi8vd3d3LnczLm9yZy9HcmFwaGljcy9TVkcvMS4xL0RURC9zdmcxMS5kdGQiPg0KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZlcnNpb249IjEuMSIgd2lkdGg9IjQ1IiBoZWlnaHQ9IjQ1Ij4NCiAgPGcgc3R5bGU9Im9wYWNpdHk6MTsgZmlsbDpub25lOyBmaWxsLW9wYWNpdHk6MTsgZmlsbC1ydWxlOmV2ZW5vZGQ7IHN0cm9rZTojMDAwMDAwOyBzdHJva2Utd2lkdGg6MS41OyBzdHJva2UtbGluZWNhcDpyb3VuZDtzdHJva2UtbGluZWpvaW46cm91bmQ7c3Ryb2tlLW1pdGVybGltaXQ6NDsgc3Ryb2tlLWRhc2hhcnJheTpub25lOyBzdHJva2Utb3BhY2l0eToxOyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCwwLjMpIj4NCiAgICA8cGF0aA0KICAgICAgZD0iTSAyMiwxMCBDIDMyLjUsMTEgMzguNSwxOCAzOCwzOSBMIDE1LDM5IEMgMTUsMzAgMjUsMzIuNSAyMywxOCINCiAgICAgIHN0eWxlPSJmaWxsOiNmZmZmZmY7IHN0cm9rZTojMDAwMDAwOyIgLz4NCiAgICA8cGF0aA0KICAgICAgZD0iTSAyNCwxOCBDIDI0LjM4LDIwLjkxIDE4LjQ1LDI1LjM3IDE2LDI3IEMgMTMsMjkgMTMuMTgsMzEuMzQgMTEsMzEgQyA5Ljk1OCwzMC4wNiAxMi40MSwyNy45NiAxMSwyOCBDIDEwLDI4IDExLjE5LDI5LjIzIDEwLDMwIEMgOSwzMCA1Ljk5NywzMSA2LDI2IEMgNiwyNCAxMiwxNCAxMiwxNCBDIDEyLDE0IDEzLjg5LDEyLjEgMTQsMTAuNSBDIDEzLjI3LDkuNTA2IDEzLjUsOC41IDEzLjUsNy41IEMgMTQuNSw2LjUgMTYuNSwxMCAxNi41LDEwIEwgMTguNSwxMCBDIDE4LjUsMTAgMTkuMjgsOC4wMDggMjEsNyBDIDIyLDcgMjIsMTAgMjIsMTAiDQogICAgICBzdHlsZT0iZmlsbDojZmZmZmZmOyBzdHJva2U6IzAwMDAwMDsiIC8+DQogICAgPHBhdGgNCiAgICAgIGQ9Ik0gOS41IDI1LjUgQSAwLjUgMC41IDAgMSAxIDguNSwyNS41IEEgMC41IDAuNSAwIDEgMSA5LjUgMjUuNSB6Ig0KICAgICAgc3R5bGU9ImZpbGw6IzAwMDAwMDsgc3Ryb2tlOiMwMDAwMDA7IiAvPg0KICAgIDxwYXRoDQogICAgICBkPSJNIDE1IDE1LjUgQSAwLjUgMS41IDAgMSAxICAxNCwxNS41IEEgMC41IDEuNSAwIDEgMSAgMTUgMTUuNSB6Ig0KICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMC44NjYsMC41LC0wLjUsMC44NjYsOS42OTMsLTUuMTczKSINCiAgICAgIHN0eWxlPSJmaWxsOiMwMDAwMDA7IHN0cm9rZTojMDAwMDAwOyIgLz4NCiAgPC9nPg0KPC9zdmc+DQo=";
        public override string PieceImageUrlBlack { get; set; } = "data:image/svg+xml;base64,PD94bWwgdmVyc2lvbj0iMS4wIiBlbmNvZGluZz0iVVRGLTgiIHN0YW5kYWxvbmU9Im5vIj8+DQo8IURPQ1RZUEUgc3ZnIFBVQkxJQyAiLS8vVzNDLy9EVEQgU1ZHIDEuMS8vRU4iICJodHRwOi8vd3d3LnczLm9yZy9HcmFwaGljcy9TVkcvMS4xL0RURC9zdmcxMS5kdGQiPg0KPHN2ZyB4bWxucz0iaHR0cDovL3d3dy53My5vcmcvMjAwMC9zdmciIHZlcnNpb249IjEuMSIgd2lkdGg9IjQ1IiBoZWlnaHQ9IjQ1Ij4NCiAgPGcgc3R5bGU9Im9wYWNpdHk6MTsgZmlsbDpub25lOyBmaWxsLW9wYWNpdHk6MTsgZmlsbC1ydWxlOmV2ZW5vZGQ7IHN0cm9rZTojMDAwMDAwOyBzdHJva2Utd2lkdGg6MS41OyBzdHJva2UtbGluZWNhcDpyb3VuZDtzdHJva2UtbGluZWpvaW46cm91bmQ7c3Ryb2tlLW1pdGVybGltaXQ6NDsgc3Ryb2tlLWRhc2hhcnJheTpub25lOyBzdHJva2Utb3BhY2l0eToxOyIgdHJhbnNmb3JtPSJ0cmFuc2xhdGUoMCwwLjMpIj4NCiAgICA8cGF0aA0KICAgICAgZD0iTSAyMiwxMCBDIDMyLjUsMTEgMzguNSwxOCAzOCwzOSBMIDE1LDM5IEMgMTUsMzAgMjUsMzIuNSAyMywxOCINCiAgICAgIHN0eWxlPSJmaWxsOiMwMDAwMDA7IHN0cm9rZTojMDAwMDAwOyIgLz4NCiAgICA8cGF0aA0KICAgICAgZD0iTSAyNCwxOCBDIDI0LjM4LDIwLjkxIDE4LjQ1LDI1LjM3IDE2LDI3IEMgMTMsMjkgMTMuMTgsMzEuMzQgMTEsMzEgQyA5Ljk1OCwzMC4wNiAxMi40MSwyNy45NiAxMSwyOCBDIDEwLDI4IDExLjE5LDI5LjIzIDEwLDMwIEMgOSwzMCA1Ljk5NywzMSA2LDI2IEMgNiwyNCAxMiwxNCAxMiwxNCBDIDEyLDE0IDEzLjg5LDEyLjEgMTQsMTAuNSBDIDEzLjI3LDkuNTA2IDEzLjUsOC41IDEzLjUsNy41IEMgMTQuNSw2LjUgMTYuNSwxMCAxNi41LDEwIEwgMTguNSwxMCBDIDE4LjUsMTAgMTkuMjgsOC4wMDggMjEsNyBDIDIyLDcgMjIsMTAgMjIsMTAiDQogICAgICBzdHlsZT0iZmlsbDojMDAwMDAwOyBzdHJva2U6IzAwMDAwMDsiIC8+DQogICAgPHBhdGgNCiAgICAgIGQ9Ik0gOS41IDI1LjUgQSAwLjUgMC41IDAgMSAxIDguNSwyNS41IEEgMC41IDAuNSAwIDEgMSA5LjUgMjUuNSB6Ig0KICAgICAgc3R5bGU9ImZpbGw6I2ZmZmZmZjsgc3Ryb2tlOiNmZmZmZmY7IiAvPg0KICAgIDxwYXRoDQogICAgICBkPSJNIDE1IDE1LjUgQSAwLjUgMS41IDAgMSAxICAxNCwxNS41IEEgMC41IDEuNSAwIDEgMSAgMTUgMTUuNSB6Ig0KICAgICAgdHJhbnNmb3JtPSJtYXRyaXgoMC44NjYsMC41LC0wLjUsMC44NjYsOS42OTMsLTUuMTczKSINCiAgICAgIHN0eWxlPSJmaWxsOiNmZmZmZmY7IHN0cm9rZTojZmZmZmZmOyIgLz4NCiAgICA8cGF0aA0KICAgICAgZD0iTSAyNC41NSwxMC40IEwgMjQuMSwxMS44NSBMIDI0LjYsMTIgQyAyNy43NSwxMyAzMC4yNSwxNC40OSAzMi41LDE4Ljc1IEMgMzQuNzUsMjMuMDEgMzUuNzUsMjkuMDYgMzUuMjUsMzkgTCAzNS4yLDM5LjUgTCAzNy40NSwzOS41IEwgMzcuNSwzOSBDIDM4LDI4Ljk0IDM2LjYyLDIyLjE1IDM0LjI1LDE3LjY2IEMgMzEuODgsMTMuMTcgMjguNDYsMTEuMDIgMjUuMDYsMTAuNSBMIDI0LjU1LDEwLjQgeiAiDQogICAgICBzdHlsZT0iZmlsbDojZmZmZmZmOyBzdHJva2U6bm9uZTsiIC8+DQogIDwvZz4NCjwvc3ZnPg0K";

        public Knight(PieceColor color) : base(color) { }

        public override Move[] GetMoves(Piece?[] pieces)
        {
           List<Move> moves = new List<Move>();
           List <ChessCoordinates> allPossibleMoves = new List<ChessCoordinates>
                { Position.ApplyOffset(2, -1),    Position.ApplyOffset(2, 1), 
                    Position.ApplyOffset(-2, -1), Position.ApplyOffset(-2, 1),
                    Position.ApplyOffset(1, 2),   Position.ApplyOffset(1, -2),
                    Position.ApplyOffset(-1, 2),  Position.ApplyOffset(-1, -2) };

            foreach(ChessCoordinates move in allPossibleMoves)
            {
                if (!move.IsValidCoordinates)
                {
                    continue;
                }

                if ( (pieces[move.ToPieceIndex()] != null && CanCapture(pieces[move.ToPieceIndex()])) || pieces[move.ToPieceIndex()] == null )
                {
                    moves.Add(new Move { newPosition = move });
                }
            }
            return moves.ToArray();
        }
    }
}
