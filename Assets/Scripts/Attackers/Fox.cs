using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Attacker))]
public class Fox : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.gameObject.GetComponent<Defender>();

        if (defender)
        {
            if (defender.GetComponent<Gravestone>())
            {
                GetComponent<Animator>().SetTrigger("Jump");
            }
            else
            {
                GetComponent<Attacker>().RespondToThreat(defender.gameObject);
            }
        }
    }
}