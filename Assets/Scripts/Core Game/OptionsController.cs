using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField]
    private Slider _volume = null;

    [Header("Gameplay")]
    [SerializeField]
    private Slider _difficulty = null;

    private float _defaultMasterVolume = GameConfiguration.DEFAULT_MASTER_VOLUME;
    private float _defaultDifficultyLevel = GameConfiguration.DEFAULT_DIFFICULTY_LEVEL;


    public delegate void MasterVolumeChanged(float volume);
    public static event MasterVolumeChanged OnMasterVolumeChanged;

    public delegate void DifficultyChanged(float difficulty);
    public static event DifficultyChanged OnDifficultyChanged;


    public void SaveAndExit()
    {
        PlayerPrefsController.Save();

        FindObjectOfType<LevelLoader>().LoadStartScene();
    }

    public void SetDefaults()
    {
        _difficulty.value = _defaultDifficultyLevel;
        _volume.value = _defaultMasterVolume;
    }

    public void SetDifficulty(float difficulty)
    {
        PlayerPrefsController.SetDifficulty(difficulty);

        if (OnDifficultyChanged != null)
        {
            OnDifficultyChanged(difficulty);
        }
    }

    public void SetMasterVolume(float volume)
    {
        PlayerPrefsController.SetMasterVolume(volume);

        if (OnMasterVolumeChanged != null)
        {
            OnMasterVolumeChanged(volume);
        }
    }

    private void Start()
    {
        _difficulty.value = PlayerPrefsController.GetDifficulty();
        _volume.value = PlayerPrefsController.GetMasterVolume();
    }
}