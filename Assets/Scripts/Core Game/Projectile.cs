using UnityEngine;

public class Projectile : MonoBehaviour
{
    [Header("Movement")]
    [SerializeField]
    private float _speed = EditorConfiguration.DEFAULT_PROJECTILE_SPEED;

    [Header("Attack")]
    [SerializeField]
    private int _attackDamage = EditorConfiguration.DEFAULT_PROJECTILE_ATTACK_DAMAGE;


    public int AttackDamage
    {
        get { return _attackDamage; }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }
}