using UnityEngine;
using System;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(Health))]
public class Defender : MonoBehaviour
{
    [SerializeField]
    private int _cost = EditorConfiguration.DEFAULT_DEFENDER_COST;

    private Animator _animator = null;
    private Health _health = null;
    private Lane _lane = null;


    public delegate void Death(Defender defender);
    public event Death OnDeath;


    public int Cost
    {
        get { return _cost; }
    }

    public Lane Lane
    {
        get { return _lane; }
        set { _lane = value; }
    }


    private void Awake()
    {
        _animator = GetComponent<Animator>();
        _health = GetComponent<Health>();
    }

    private void Die()
    {
        Destroy(gameObject);
    }

    private void HealthStateChanged(Health.HealthState state)
    {
        if (state == Health.HealthState.Dead)
        {
            if (OnDeath != null)
            {
                OnDeath(this);
            }

            Die();
        }
    }

    private void OnDisable()
    {
        _health.OnStateChanged -= HealthStateChanged;
        LevelController.OnLevelComplete -= StopAnimation;
        LevelController.OnLevelIncomplete -= StopAnimation;
    }

    private void OnEnable()
    {
        _health.OnStateChanged += HealthStateChanged;
        LevelController.OnLevelComplete += StopAnimation;
        LevelController.OnLevelIncomplete += StopAnimation;
    }

    private void RespondToThreat()
    {
        if (_animator.ContainsParameter(GameConfiguration.DEFENDER_ATTACKING_PARAMETER))
        {
            if (_lane.Attackers.transform.childCount > 0)
            {
                _animator.SetBool(GameConfiguration.DEFENDER_ATTACKING_PARAMETER, true);
            }
            else
            {
                _animator.SetBool(GameConfiguration.DEFENDER_ATTACKING_PARAMETER, false);
            }
        }
    }

    private void StopAnimation()
    {
        _animator.enabled = false;
    }

    private void Update()
    {
        RespondToThreat();
    }
}