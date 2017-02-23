using UnityEngine;
using UnityEngine.UI;

public class GameTimer : MonoBehaviour
{
    public float levelSeconds = 100;

    private Slider slider;
    private AudioSource audioSource;
    private bool isEndOfLevel = false;
    private LevelManager levelManager;
    private GameObject winLabel;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        slider = gameObject.GetComponent<Slider>();
        audioSource = gameObject.GetComponent<AudioSource>();
        levelManager = GameObject.FindObjectOfType<LevelManager>();
        FindYouWin();
        winLabel.SetActive(false);
    }

    /// <summary>
    /// Locates the YouWin GameObject
    /// </summary>
    private void FindYouWin()
    {
        winLabel = GameObject.Find("You Win");

        if (!winLabel)
        {
            Debug.LogWarning("Please create You Win object");
        }
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        slider.value = 1 - (Time.timeSinceLevelLoad / levelSeconds);

        bool timeIsUp = (Time.timeSinceLevelLoad >= levelSeconds);

        if (timeIsUp && !isEndOfLevel)
        {
            HandleWinCondition();
        }
    }

    /// <summary>
    /// Handles the player winning the game
    /// </summary>
    private void HandleWinCondition()
    {
        DestroyAllTaggedObjects();
        audioSource.Play();
        winLabel.SetActive(true);
        Invoke("LoadNextLevel", audioSource.clip.length);
        isEndOfLevel = true;
    }

    /// <summary>
    /// Destroys all objects with DestroyOnWin tag
    /// </summary>
    private void DestroyAllTaggedObjects()
    {
        GameObject[] taggedObjectArray = GameObject.FindGameObjectsWithTag("DestroyOnWin");

        foreach (GameObject taggedObject in taggedObjectArray)
        {
            Destroy(taggedObject);
        }
    }

    /// <summary>
    /// Loads the next level
    /// </summary>
    private void LoadNextLevel()
    {
        levelManager.LoadNextLevel();
    }
}
