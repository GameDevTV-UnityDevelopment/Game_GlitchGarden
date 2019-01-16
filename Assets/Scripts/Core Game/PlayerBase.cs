using UnityEngine;

public class PlayerBase : MonoBehaviour
{
    private Lives _lives = null;


    private void Awake()
    {
        _lives = FindObjectOfType<Lives>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            if (_lives.Count > 0)
            {
                _lives.Decrease(GameConfiguration.BASE_ATTACK_DAMAGE);
            }

            attacker.GetComponent<Health>().InstaDeath();
        }

        Destroy(collision.gameObject);
    }
}