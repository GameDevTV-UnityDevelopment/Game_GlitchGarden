using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]
public class LevelTimer : MonoBehaviour
{
    private float _duration = 0f;
    private float _progress = 0f;
    private bool _running = false;
    private Slider _slider = null;


    public delegate void Complete();
    public static event Complete OnComplete;


    private void Awake()
    {
        _slider = GetComponent<Slider>();
    }

    private void OnDisable()
    {
        LevelController.OnSetLevelTimer -= Initialise;
        LevelController.OnLevelIncomplete -= Stop;
    }

    private void OnEnable()
    {
        LevelController.OnSetLevelTimer += Initialise;
        LevelController.OnLevelIncomplete += Stop;
    }

    private void Initialise(float duration)
    {
        _running = true;
        _duration = duration;
    }

    private void Stop()
    {
        _running = false;
    }

    private void Update()
    {
        if (_running)
        {
            _progress = Time.timeSinceLevelLoad / _duration;

            _slider.value = _progress;

            if (Time.timeSinceLevelLoad >= _duration)
            {
                _running = false;

                if (OnComplete != null)
                {
                    OnComplete();
                }
            }
        }
    }
}