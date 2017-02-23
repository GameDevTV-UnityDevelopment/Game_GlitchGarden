using UnityEngine;
using UnityEngine.UI;

public class OptionsController : MonoBehaviour
{
    public LevelManager levelManager;
    public Slider volumeSlider, diffSlider;

    private MusicManager musicManager;

    /// <summary>
    /// Initialise
    /// </summary>
    void Start()
    {
        musicManager = GameObject.FindObjectOfType<MusicManager>();

        volumeSlider.value = PlayerPrefsManager.GetMasterVolume();
        diffSlider.value = PlayerPrefsManager.GetDifficulty();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        musicManager.SetVolume(volumeSlider.value);
    }

    /// <summary>
    /// Save player preferences and exit options
    /// </summary>
    public void SaveAndExit()
    {
        PlayerPrefsManager.SetMasterVolume(volumeSlider.value);
        PlayerPrefsManager.SetDifficulty(diffSlider.value);

        levelManager.LoadLevel("01a Start");
    }

    /// <summary>
    /// Set default game options
    /// </summary>
    public void SetDefaults()
    {
        volumeSlider.value = 0.8f;
        diffSlider.value = 2f;
    }
}