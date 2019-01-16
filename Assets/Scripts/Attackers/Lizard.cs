using UnityEngine;

[RequireComponent(typeof(Attacker))]
public class Lizard : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Defender defender = collision.gameObject.GetComponent<Defender>();

        if (defender)
        {
            GetComponent<Attacker>().RespondToThreat(defender.gameObject);
        }
    }
}