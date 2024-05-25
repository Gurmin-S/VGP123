using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Projectile : MonoBehaviour
{
    public float lifetime;

    //speed value is set by shoot script when the player fires
    [HideInInspector]
    public float xVel;
    [HideInInspector]
    public float yVel;

    // Start is called before the first frame update
    void Start()
    {
        if (lifetime <= 0) lifetime = 2.0f;

        GetComponent<Rigidbody2D>().velocity = new Vector2(xVel, yVel);
        Destroy(gameObject, lifetime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with another object (not a trigger collider)
        if (!collision.collider.isTrigger)
        {
            // Destroy the projectile when it collides with anything
            Destroy(gameObject);
        }
    }
}