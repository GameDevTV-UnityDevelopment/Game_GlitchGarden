using UnityEngine;

public class Shredder : MonoBehaviour
{
    /// <summary>
    /// Event handler for a triggered collision
    /// </summary>
    /// <param name="collision">The other Collider2D involved in the collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(collision.gameObject);
    }
}
