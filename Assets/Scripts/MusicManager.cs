using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicManager : MonoBehaviour
{
    public AudioClip[] levelMusicChangeArray;

    private AudioSource audioSource;

    /// <summary>
    /// Pre-Initialisation
    /// </summary>
    private void Awake()
    {
        DontDestroyOnLoad(gameObject);
    }

    /// <summary>
    /// Initialise
    /// </summary>
    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();

        audioSource.volume = PlayerPrefsManager.GetMasterVolume();
    }

    /// <summary>
    /// Called when the object becomes enabled and active
    /// </summary>
    void OnEnable()
    {
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    /// <summary>
    /// Called when the object becomes disabled or inactive.
    /// </summary>
    void OnDisable()
    {
        SceneManager.sceneLoaded -= OnSceneLoaded;
    }

    /// <summary>
    /// Plays music on level change
    /// </summary>
    private void OnSceneLoaded(Scene scene, LoadSceneMode mode)
    {
        AudioClip thisLevelMusic = levelMusicChangeArray[scene.buildIndex];

        if (thisLevelMusic)     // if there's some music attached
        {
            audioSource.clip = levelMusicChangeArray[scene.buildIndex];
            audioSource.loop = true;
            audioSource.Play();
        }
    }

    /// <summary>
    /// Changes the volume of the music
    /// </summary>
    public void SetVolume(float volume)
    {
        audioSource.volume = volume;
    }
}