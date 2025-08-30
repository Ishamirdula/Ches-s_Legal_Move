using UnityEngine;

namespace Chess.Scripts.Core
{
    public class Pawn : BasePiece
    {
        protected override void ShowLegalMoves()
        {
            int row = positionHandler.row;
            int col = positionHandler.column;

            int direction = isWhite ? -1 : 1; // Black moves UP , White moves DOWN

            int oneStepRow = row + direction;
            int twoStepRow = row + 2 * direction;

            // One step 
            if (IsTileEmpty(oneStepRow, col))
            {
                HighlightIfValid(oneStepRow, col);

                // Two steps 
                if ((isWhite && row == 6 || !isWhite && row == 1) &&
                    IsTileEmpty(twoStepRow, col))
                {
                    HighlightIfValid(twoStepRow, col);
                }
            }

            // Diagonal attack
            CheckAttack(oneStepRow, col - 1);
            CheckAttack(oneStepRow, col + 1);
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

        private void CheckAttack(int row, int col)
        {
            if (!IsValidPosition(row, col)) return;

            Debug.Log($"Checking attack at ({row}, {col})");

            var piece = GetPieceAt(row, col);
            if (piece != null)
            {
                Debug.Log($"Piece found. piece.isWhite = {piece.isWhite}, this.isWhite = {this.isWhite}");

                if (piece.isWhite != this.isWhite)
                {
                    Debug.Log("Enemy detected — highlighting red.");
                    ChessBoardPlacementHandler.Instance.HighlightRed(row, col);
                }
            }
        }

        private bool IsTileEmpty(int row, int col)
        {
            if (!IsValidPosition(row, col)) return false;

            var tile = ChessBoardPlacementHandler.Instance.GetTile(row, col);
            return tile.transform.childCount == 0;
        }

    }
}