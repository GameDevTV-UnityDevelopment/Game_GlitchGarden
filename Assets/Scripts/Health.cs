using UnityEngine;

public class Health : MonoBehaviour
{
    public float health = 100f;

    /// <summary>
    /// Reduces health by the specified amount of damage
    /// </summary>
    /// <param name="damage">The amount of damage</param>
    public void DealDamage(float damage)
    {
        health -= damage;

        if (health <= 0)
        {
            // Optionally trigger an animation
            DestroyObject();
        }
    }

    /// <summary>
    /// Destroys the GameObject
    /// </summary>
    private void DestroyObject()
    {
        Destroy(gameObject);
    }
}
