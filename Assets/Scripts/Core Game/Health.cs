using UnityEngine;
using System;

public class Health : MonoBehaviour
{
    [SerializeField]
    private int _points = EditorConfiguration.DEFAULT_HEALTH_POINTS;


    public enum HealthState { Alive, Dead };


    public delegate void StateChanged(HealthState state);
    public event StateChanged OnStateChanged;


    public void Decrease(int points)
    {
        _points -= points;

        if (_points <= 0)
        {
            if (OnStateChanged != null)
            {
                OnStateChanged(HealthState.Dead);
            }
        }
    }

    public void InstaDeath()
    {
        _points = 0;

        if (OnStateChanged != null)
        {
            OnStateChanged(HealthState.Dead);
        }
    }
}