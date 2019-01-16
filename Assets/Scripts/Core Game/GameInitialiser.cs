using UnityEngine;

public class GameInitialiser : MonoBehaviour
{
    private void Awake()
    {
        PlayerPrefsController.Initialise();
    }
}