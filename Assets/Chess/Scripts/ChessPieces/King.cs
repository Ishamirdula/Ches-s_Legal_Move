using UnityEngine;

namespace Chess.Scripts.Core
{
    public class King : BasePiece
    {
        protected override void ShowLegalMoves()
        {
            int row = positionHandler.row;
            int col = positionHandler.column;

            TryMove(row + 1, col);     // Down
            TryMove(row - 1, col);     // Up
            TryMove(row, col + 1);     // Right
            TryMove(row, col - 1);     // Left
            TryMove(row + 1, col + 1); // Down-Right
            TryMove(row + 1, col - 1); // Down-Left
            TryMove(row - 1, col + 1); // Up-Right
            TryMove(row - 1, col - 1); // Up-Left
        }

        private void TryMove(int row, int col)
        {
            if (!IsValidPosition(row, col)) return;

            BasePiece piece = GetPieceAt(row, col);

            if (piece == null)
            {
                ChessBoardPlacementHandler.Instance.Highlight(row, col);
            }
            else if (piece.isWhite != this.isWhite)
            {
                ChessBoardPlacementHandler.Instance.HighlightRed(row, col);
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
