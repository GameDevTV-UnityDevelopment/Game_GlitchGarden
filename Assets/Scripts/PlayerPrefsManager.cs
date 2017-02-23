using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPrefsManager : MonoBehaviour
{
    const string MASTER_VOLUME_KEY = "master_volume";
    const string DIFFICULTY_KEY = "difficulty";
    const string LEVEL_KEY = "level_unlocked_";

    /// <summary>
    /// Sets the the master volume player preference
    /// </summary>
    /// <param name="volume">The volume level to set</param>
    public static void SetMasterVolume(float volume)
    {
        if (volume >= 0f && volume <= 1f)
        {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        }
        else
        {
            Debug.LogError("Master volume out of range.");
        }
    }

    /// <summary>
    /// Gets the master volume player preference
    /// </summary>
    /// <returns>float</returns>
    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    /// <summary>
    /// Sets the specified level to unlocked within the player preferences
    /// </summary>
    /// <param name="level">The level to unlock</param>
    public static void UnlockLevel(int level)
    {
        if (level <= SceneManager.sceneCountInBuildSettings - 1)     // this won't take into account disabled scenes
        {
            PlayerPrefs.SetInt(LEVEL_KEY + level.ToString(), 1);     // use 1 for true
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order.");
        }
    }

    /// <summary>
    /// Indicates whether the specified level is unlocked within the player preferences
    /// </summary>
    /// <param name="level"></param>
    /// <returns>Bool</returns>
    public static bool IsLevelUnlocked(int level)
    {
        int levelValue = PlayerPrefs.GetInt(LEVEL_KEY + level.ToString());
        bool isLevelUnlocked = (levelValue == 1);

        if (level <= SceneManager.sceneCountInBuildSettings - 1)
        {
            return isLevelUnlocked;
        }
        else
        {
            Debug.LogError("Trying to unlock level not in build order.");
            return false;
        }
    }

    /// <summary>
    /// Sets the specified difficulty player preference
    /// </summary>
    /// <param name="difficulty">The difficulty to set</param>
    public static void SetDifficulty(float difficulty)
    {
        if (difficulty >= 1f && difficulty <= 3f)
        {
            PlayerPrefs.SetFloat(DIFFICULTY_KEY, difficulty);
        }
        else
        {
            Debug.LogError("Difficulty out of range.");
        }
    }

    /// <summary>
    /// Gets the difficulty player preference
    /// </summary>
    /// <returns>Float</returns>
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(DIFFICULTY_KEY);
    }
}
