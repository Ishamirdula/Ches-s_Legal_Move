using UnityEngine;

namespace Chess.Scripts.Core
{
    public class Bishop : BasePiece
    {
        protected override void ShowLegalMoves()
        {
            int row = positionHandler.row;
            int col = positionHandler.column;

            ShowMovesInDirection(row, col, 1, 1);    // Down-right
            ShowMovesInDirection(row, col, 1, -1);   // Down-left
            ShowMovesInDirection(row, col, -1, 1);   // Up-right
            ShowMovesInDirection(row, col, -1, -1);  // Up-left
        }

        private void ShowMovesInDirection(int row, int col, int rowStep, int colStep)
        {
            int currentRow = row + rowStep;
            int currentCol = col + colStep;

            while (IsValidPosition(currentRow, currentCol))
            {
                BasePiece piece = GetPieceAt(currentRow, currentCol);

                if (piece == null)
                {
                    ChessBoardPlacementHandler.Instance.Highlight(currentRow, currentCol);
                }
                else
                {
                    if (piece.isWhite != this.isWhite)
                    {
                        ChessBoardPlacementHandler.Instance.HighlightRed(currentRow, currentCol);
                    }
                    break;
                }

                currentRow += rowStep;
                currentCol += colStep;
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
