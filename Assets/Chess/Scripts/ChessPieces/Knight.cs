using UnityEngine;

namespace Chess.Scripts.Core
{
    public class Knight : BasePiece
    {
        protected override void ShowLegalMoves()
        {
            int row = positionHandler.row;
            int col = positionHandler.column;

            int[,] moves = new int[,]
            {
                { -2, -1 }, { -2, 1 },
                { -1, -2 }, { -1, 2 },
                { 1, -2 },  { 1, 2 },
                { 2, -1 },  { 2, 1 }
            };

            for (int i = 0; i < moves.GetLength(0); i++)
            {
                int targetRow = row + moves[i, 0];
                int targetCol = col + moves[i, 1];

                if (IsValidPosition(targetRow, targetCol))
                {
                    BasePiece piece = GetPieceAt(targetRow, targetCol);
                    if (piece == null)
                    {
                        ChessBoardPlacementHandler.Instance.Highlight(targetRow, targetCol);
                    }
                    else if (piece.isWhite != this.isWhite)
                    {
                        ChessBoardPlacementHandler.Instance.HighlightRed(targetRow, targetCol);
                    }
                }
            }
        }

        private BasePiece GetPieceAt(int row, int col)
        {
            BasePiece[] allPieces = FindObjectsOfType<BasePiece>();
            foreach (BasePiece piece in allPieces)
            {
                if (piece.positionHandler.row == row && piece.positionHandler.column == col)
                    return piece;
            }
            return null;
        }
    }
}
