using UnityEngine;

public static class PlayerPrefsController
{
    public static float GetDifficulty()
    {
        return PlayerPrefs.GetFloat(GameConfiguration.PLAYERPREFS_KEY_DIFFICULTY);
    }

    public static float GetMasterVolume()
    {
        return PlayerPrefs.GetFloat(GameConfiguration.PLAYERPREFS_KEY_MASTER_VOLUME);
    }

    public static void Initialise()
    {
        bool savePrefs = false;

        if (!PlayerPrefs.HasKey(GameConfiguration.PLAYERPREFS_KEY_DIFFICULTY))
        {
            PlayerPrefs.SetFloat(GameConfiguration.PLAYERPREFS_KEY_DIFFICULTY, GameConfiguration.DEFAULT_DIFFICULTY_LEVEL);
            savePrefs = true;
        }

        if (!PlayerPrefs.HasKey(GameConfiguration.PLAYERPREFS_KEY_MASTER_VOLUME))
        {
            PlayerPrefs.SetFloat(GameConfiguration.PLAYERPREFS_KEY_MASTER_VOLUME, GameConfiguration.DEFAULT_MASTER_VOLUME);
            savePrefs = true;
        }

        if (savePrefs)
        {
            PlayerPrefs.Save();
        }
    }

    public static void Save()
    {
        PlayerPrefs.Save();
    }

    public static void SetDifficulty(float difficulty)
    {
        difficulty = ValidateValue(difficulty, GameConfiguration.MIN_DIFFICULTY, GameConfiguration.MAX_DIFFICULTY);

        PlayerPrefs.SetFloat(GameConfiguration.PLAYERPREFS_KEY_DIFFICULTY, difficulty);
    }

    public static void SetMasterVolume(float volume)
    {
        volume = ValidateValue(volume, GameConfiguration.MIN_VOLUME, GameConfiguration.MAX_VOLUME);

        PlayerPrefs.SetFloat(GameConfiguration.PLAYERPREFS_KEY_MASTER_VOLUME, volume);
    }

    private static float ValidateValue(float value, float minValue, float maxValue)
    {
        if (value < minValue)
        {
            value = minValue;
        }
        else if (value > maxValue)
        {
            value = maxValue;
        }

        return value;
    }
}