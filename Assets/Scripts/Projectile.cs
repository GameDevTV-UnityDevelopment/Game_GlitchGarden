using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed, damage;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        gameObject.GetComponent<Transform>().Translate(Vector3.right * speed * Time.deltaTime);
    }

    /// <summary>
    /// Event handler for a triggered collision
    /// </summary>
    /// <param name="collision">The other Collider2D involved in this collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();
        Health health = collision.gameObject.GetComponent<Health>();

        if (attacker && health)
        {
            health.DealDamage(damage);
            Destroy(gameObject);
        }

    }
}
