using UnityEngine;

public class GraveStone : MonoBehaviour
{
    private Animator animator;

    /// <summary>
    /// Initialisation
    /// </summary>
    private void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// Event handler for a triggered collision
    /// </summary>
    /// <param name="collision">The other Collider2D involved in the collision</param>
    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            animator.SetTrigger("underAttackTrigger");
        }
    }
}