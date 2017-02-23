using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Attacker : MonoBehaviour
{
    [Tooltip("Average number of seconds between appearances")]
    public float seenEverySeconds;

    private float currentSpeed;
    private GameObject currentTarget;
    private Animator animator;

    /// <summary>
    /// Initialise
    /// </summary>
    void Start()
    {
        animator = gameObject.GetComponent<Animator>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>         
    void Update()
    {
        transform.Translate(Vector3.left * currentSpeed * Time.deltaTime);

        if (!currentTarget)     // Note: This seems significantly expensive.  Should send a message as the currentTarget is destroyed.
        {
            animator.SetBool("isAttacking", false);
        }
    }

    /// <summary>
    /// Sets the speed of the attacker
    /// </summary>
    /// <param name="speed">The speed</param>
    public void SetSpeed(float speed)
    {
        currentSpeed = speed;
    }

    /// <summary>
    /// Causes damage to target
    /// </summary>
    /// <param name="damage">The amount of damage to cause</param>
    /// <remarks>Called from the animator at time of attack</remarks>
    public void StrikeCurrentTarget(float damage)
    {
        if (currentTarget)
        {
            Health health = currentTarget.GetComponent<Health>();

            if (health)
            {
                health.DealDamage(damage);
            }
        }
    }

    /// <summary>
    /// Places the attacker into attack mode
    /// </summary>
    public void Attack(GameObject obj)
    {
        currentTarget = obj;
    }
}
