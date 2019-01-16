using UnityEngine;

[RequireComponent(typeof(Animator))]
public class SliderHandle : MonoBehaviour
{
    private Animator _animator = null;


    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    private void OnDisable()
    {
        LevelTimer.OnComplete -= StopAnimation;
        LevelController.OnLevelIncomplete -= StopAnimation;
    }

    private void OnEnable()
    {
        LevelTimer.OnComplete += StopAnimation;
        LevelController.OnLevelIncomplete += StopAnimation;
    }

    private void StopAnimation()
    {
        _animator.enabled = false;
    }
}