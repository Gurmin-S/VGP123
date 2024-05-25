using UnityEngine;

public class Destroy : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the colliding object has a tag "Player"
        if (collision.gameObject.CompareTag("Player"))
        {
            // Destroy the coin when it collides with the player
            Destroy(gameObject);
        }
    }
}
