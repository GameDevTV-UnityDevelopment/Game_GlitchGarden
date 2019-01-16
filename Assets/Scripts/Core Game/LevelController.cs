using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class LevelController : MonoBehaviour
{
    [Tooltip("Level duration in seconds")]
    [SerializeField]
    private float _levelDuration = EditorConfiguration.DEFAULT_LEVEL_DURATION;

    [Header("Audio")]
    [SerializeField]
    private AudioClip _levelCompleteSFX = null;

    [SerializeField]
    private AudioClip _levelIncompleteSFX = null;

    private AudioSource _audioSource = null;
    private bool _levelIsRunning = false;
    private LevelLoader _levelLoader = null;
    private bool _levelTimerComplete = false;


    public delegate void LevelComplete();
    public static event LevelComplete OnLevelComplete;

    public delegate void LevelIncomplete();
    public static event LevelIncomplete OnLevelIncomplete;

    public delegate void SetLevelTimer(float duration);
    public static event SetLevelTimer OnSetLevelTimer;


    private void Awake()
    {
        _levelIsRunning = true;
        _audioSource = GetComponent<AudioSource>();
        _levelLoader = FindObjectOfType<LevelLoader>();
    }

    private void LevelLost()
    {
        _levelIsRunning = false;

        _levelLoader.LoadUILevelIncomplete();

        PlayAudioClip(_levelIncompleteSFX);

        if (OnLevelIncomplete != null)
        {
            OnLevelIncomplete();
        }
    }

    private void LevelTimerComplete()
    {
        _levelTimerComplete = true;
    }

    private void LevelWon()
    {
        if (_levelLoader.HasMoreLevels())
        {
            _levelLoader.LoadUILevelComplete();
        }
        else
        {
            _levelLoader.LoadUIGameWon();
        }        

        PlayAudioClip(_levelCompleteSFX);

        if (OnLevelComplete != null)
        {
            OnLevelComplete();
        }
    }

    private void OnDisable()
    {
        LevelTimer.OnComplete -= LevelTimerComplete;
        Lives.OnDeath -= LevelLost;
    }

    private void OnEnable()
    {
        LevelTimer.OnComplete += LevelTimerComplete;
        Lives.OnDeath += LevelLost;
    }

    private void PlayAudioClip(AudioClip audioClip)
    {
        _audioSource.clip = audioClip;
        _audioSource.Play();
    }

    private void Start()
    {
        if (OnSetLevelTimer != null)
        {
            OnSetLevelTimer(_levelDuration);
        }
    }

    private void Update()
    {
        if (_levelIsRunning)
        {
            if (_levelTimerComplete && Attacker.Count == 0)
            {
                _levelIsRunning = false;

                LevelWon();
            }
        }
    }
}