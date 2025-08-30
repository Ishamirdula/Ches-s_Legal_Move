using UnityEngine;

public class HighlightTriggerHandler : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("ChessPiece"))
        {
            Destroy(gameObject); // Destroy highlight if it touches a chess piece
        }
    }
}
