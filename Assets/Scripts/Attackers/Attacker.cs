using UnityEngine;
using System;

[RequireComponent(typeof(Rigidbody2D))]
[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class Attacker : MonoBehaviour
{
    [SerializeField]
    private GameObject _deathEffectsPrefab = null;

    private Animator _animator = null;
    private static int _count = 0;
    private GameObject _currentTarget = null;
    private Health _health = null;
    private bool _isAttacking = false;
    private Lane _lane = null;
    private Rigidbody2D _rigidBody2D = null;
    private float _walkSpeed = 1f;


    public static int Count
    {
        get { return _count; }
    }

    public Lane Lane
    {
        set { _lane = value; }
    }


    public void Attack(int damage)
    {
        if (_currentTarget)
        {
            Health health = _currentTarget.GetComponent<Health>();

            if (health)
            {
                health.Decrease(damage);
            }
        }
    }

    public void RespondToThreat(GameObject target)
    {
        _rigidBody2D.sleepMode = RigidbodySleepMode2D.NeverSleep;

        if (_animator.ContainsParameter(GameConfiguration.ATTACKER_ATTACKING_PARAMETER))
        {
            _isAttacking = true;
            _currentTarget = target;
            _animator.SetBool(GameConfiguration.ATTACKER_ATTACKING_PARAMETER, _isAttacking);
        }
    }

    public void SetWalkSpeed(float speed)
    {
        _walkSpeed = speed;
    }

    private void Awake()
    {
        _count++;

        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
        _rigidBody2D = GetComponent<Rigidbody2D>();
    }

    private void Die()
    {
        _count--;

        GameObject deathFX = Instantiate(_deathEffectsPrefab, transform.position, transform.rotation);

        if (_lane)
        {
            deathFX.transform.parent = _lane.DeathFX.transform;
        }

        Destroy(gameObject);
    }

    private void HealthStateChanged(Health.HealthState state)
    {
        if (state == Health.HealthState.Dead)
        {
            Die();
        }
    }

    private void OnDisable()
    {
        _health.OnStateChanged -= HealthStateChanged;
        LevelController.OnLevelIncomplete -= Stop;
    }

    private void OnEnable()
    {
        _health.OnStateChanged += HealthStateChanged;
        LevelController.OnLevelIncomplete += Stop;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Projectile projectile = collision.gameObject.GetComponent<Projectile>();

        if (projectile)
        {
            _health.Decrease(projectile.AttackDamage);
        }
    }

    private void Stop()
    {
        _animator.enabled = false;
        _walkSpeed = 0f;
    }

    private void Update()
    {
        if (!_currentTarget)
        {
            _rigidBody2D.sleepMode = RigidbodySleepMode2D.StartAwake;
            Walk();
        }
    }

    private void Walk()
    {
        if (_isAttacking)
        {
            _isAttacking = false;
            _animator.SetBool(GameConfiguration.ATTACKER_ATTACKING_PARAMETER, _isAttacking);
        }

        transform.Translate(Vector2.left * _walkSpeed * Time.deltaTime);
    }
}