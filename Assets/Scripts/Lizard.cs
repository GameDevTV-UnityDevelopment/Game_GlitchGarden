using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private Animator anim;
    private Attacker attacker;

    /// <summary>
    ///  Initialisation
    /// </summary>
    void Start()
    {
        anim = gameObject.GetComponent<Animator>();
        attacker = gameObject.GetComponent<Attacker>();
    }

    /// <summary>
    /// Event handler for a triggered collision
    /// </summary>
    /// <param name="collision">The other Collider2D involved in the collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject obj = collision.gameObject;

        // Leave the method if not colliding with a defender
        if (!obj.GetComponent<Defender>())
        {
            return;
        }

        anim.SetBool("isAttacking", true);
        attacker.Attack(obj);
    }
}
