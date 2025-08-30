using UnityEngine;

namespace Chess.Scripts.Core
{
    [RequireComponent(typeof(ChessPlayerPlacementHandler))]
    public abstract class BasePiece : MonoBehaviour
    {
        public ChessPlayerPlacementHandler positionHandler;

        public bool isWhite = true; 

        protected virtual void Awake()
        {
            positionHandler = GetComponent<ChessPlayerPlacementHandler>();
        }


        protected bool isShowingMoves = false;

        protected virtual void OnMouseDown()
        {
            // Clear all highlights
            ChessBoardPlacementHandler.Instance.ClearHighlights();

            if (isShowingMoves)
            {
                // Turn off highlights
                isShowingMoves = false;
            }
            else
            {
                // Turn on highlights
                ShowLegalMoves();
                isShowingMoves = true;
            }
        }


        protected abstract void ShowLegalMoves();

        protected bool IsValidPosition(int row, int col)
        {
            return row >= 0 && row < 8 && col >= 0 && col < 8;
        }

        protected void HighlightIfValid(int row, int col)
        {
            if (IsValidPosition(row, col))
            {
                ChessBoardPlacementHandler.Instance.Highlight(row, col);
            }
        }

    }
}