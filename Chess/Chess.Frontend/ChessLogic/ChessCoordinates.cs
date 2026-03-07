using System.Data.Common;

namespace Chess.Frontend.ChessLogic.Pieces
{
    public class ChessCoordinates
    {
        private int letter;

        //A -- 1, F == 8
        public required int Letter 
        {
            get 
            {
                return letter;
            } 
            set 
            {
                if (IsValidCoordinates)
                {
                    if (value >= 1 && value <= Game.Columns) { letter = value; IsValidCoordinates = true; }
                    else { letter = -1; IsValidCoordinates = false; }
                }
            } 
        }

        private int number;

        // form 1 to 8
        public required int Number
        {
            get
            {
                return number;
            }
            set
            {
                if (IsValidCoordinates)
                {
                    if (value >= 1 && value <= Game.Rows) { number = value; IsValidCoordinates = true; }
                    else { number = -1; IsValidCoordinates = false; }
                }
            }
        }

        public bool IsValidCoordinates = true;

        public static ChessCoordinates FromPieceIndex(int pieceIndex)
        {
            int y = pieceIndex / Game.Rows;
            int number = Game.Rows - (y + 1) + 1;

            int x = pieceIndex % Game.Rows;
            int letter = x + 1;

            return new ChessCoordinates { Letter = letter, Number = number };
        }

        public int ToPieceIndex()
        {
            int y = Game.Columns - number; 
            return y * Game.Rows + (letter -1);
        }

        public ChessCoordinates ApplyOffset(int xOffset, int yOffset)
        {
            ChessCoordinates transformedCoordinates = new ChessCoordinates { Letter = letter + xOffset, Number = number + yOffset };
            return transformedCoordinates;
        }

        public override string ToString()
        {
            if(IsValidCoordinates == true)
            {
                return $"{Convert.ToChar(96 + letter)}{number}";
            }
            else
            {
                return "NaC";
            }
        }
    }
}