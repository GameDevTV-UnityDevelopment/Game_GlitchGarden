using UnityEngine;

public class LoseCollider : MonoBehaviour
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
    /// Event handler for a triggered collision
    /// </summary>
    /// <param name="collision">The other Collider2D involved in the collision</param>
    private void OnTriggerEnter2D(Collider2D collision)
    {
        levelManager.LoadLevel("03b Lose");
    }
}
