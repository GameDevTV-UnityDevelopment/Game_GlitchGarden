using UnityEngine;

public class Gravestone : MonoBehaviour
{
    private Animator _animator = null;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        Attacker attacker = collision.gameObject.GetComponent<Attacker>();

        if (attacker)
        {
            if (_animator.ContainsParameter(GameConfiguration.DEFENDER_BLOCKING_PARAMETER))
            {
                _animator.SetTrigger(GameConfiguration.DEFENDER_BLOCKING_PARAMETER);
            }
        }
    }
}