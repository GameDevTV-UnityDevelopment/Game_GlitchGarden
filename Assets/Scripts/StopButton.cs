using UnityEngine;

public class StopButton : MonoBehaviour
{
    private LevelManager levelManager;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();
    }

    /// <summary>
    /// Handles the mouse click event
    /// </summary>
    private void OnMouseDown()
    {
        levelManager.LoadLevel("01a Start");
    }
}
