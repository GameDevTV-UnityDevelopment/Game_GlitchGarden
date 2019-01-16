using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class LevelLoader : MonoBehaviour
{
    [SerializeField]
    private float _splashScreenLoadDelay = EditorConfiguration.DEFAULT_SPLASH_SCREEN_LOAD_DELAY;

    private int _currentSceneIndex = 0;


    public bool HasMoreLevels()
    {
        bool result = false;

        if (_currentSceneIndex + 1 < SceneManager.sceneCountInBuildSettings)
        {
            result = true;
        }

        return result;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(_currentSceneIndex + 1);
    }

    public IEnumerator LoadNextScene(float loadDelay)
    {
        yield return new WaitForSeconds(loadDelay);
        LoadNextScene();
    }

    public void LoadOptionsScene()
    {
        LoadScene(GameConfiguration.OPTIONS_SCREEN);
    }

    public void LoadStartScene()
    {
        LoadScene(GameConfiguration.START_SCREEN);
    }

    public void LoadUIGameWon()
    {
        LoadSceneAsync(GameConfiguration.GAME_WON, LoadSceneMode.Additive);
    }

    public void LoadUILevelComplete()
    {
        LoadSceneAsync(GameConfiguration.LEVEL_COMPLETE, LoadSceneMode.Additive);

        StartCoroutine(LoadSceneAsync(_currentSceneIndex + 1, LoadSceneMode.Single, 4f));
    }

    public void LoadUILevelIncomplete()
    {
        LoadSceneAsync(GameConfiguration.LEVEL_INCOMPLETE, LoadSceneMode.Additive);
    }

    public void RestartCurrentScene()
    {
        SceneManager.LoadScene(_currentSceneIndex);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(GameConfiguration.FIRST_LEVEL);
    }

    private void LoadScene(string sceneName)
    {
        SceneManager.LoadScene(sceneName);
    }

    private void LoadSceneAsync(string name, LoadSceneMode mode)
    {
        SceneManager.LoadSceneAsync(name, mode);
    }

    private IEnumerator LoadSceneAsync(int buildIndex, LoadSceneMode mode, float delay)
    {
        yield return new WaitForSeconds(delay);
        SceneManager.LoadSceneAsync(buildIndex, mode);
    }

    private void Start()
    {
        _currentSceneIndex = SceneManager.GetActiveScene().buildIndex;

        if (_currentSceneIndex == 0)
        {
            StartCoroutine(LoadNextScene(_splashScreenLoadDelay));
        }
    }
}