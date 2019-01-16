using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(AudioSource))]
public class MusicPlayer : MonoBehaviour
{
    private AudioSource _audioSource = null;


    private void Awake()
    {
        DontDestroyOnLoad(gameObject);

        _audioSource = GetComponent<AudioSource>();
    }

    private void OnDisable()
    {
        OptionsController.OnMasterVolumeChanged -= SetVolume;
        SceneManager.sceneLoaded -= Play;
    }

    private void OnEnable()
    {
        OptionsController.OnMasterVolumeChanged += SetVolume;
        SceneManager.sceneLoaded += Play;
    }

    private void Play(Scene scene, LoadSceneMode loadSceneMode)
    {
        if (!_audioSource.isPlaying)
        {
            if (scene.buildIndex > 0)
            {
                _audioSource.loop = true;
                _audioSource.Play();
            }
        }
    }


    private void SetVolume(float volume)
    {
        _audioSource.volume = volume;
    }

    private void Start()
    {
        _audioSource.volume = PlayerPrefsController.GetMasterVolume();
    }
}