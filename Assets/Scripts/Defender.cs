using UnityEngine;

public class Defender : MonoBehaviour
{
    public int starCost = 100;
    private StarDisplay starDisplay;

    /// <summary>
    /// Initialise
    /// </summary>
    private void Start()
    {
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
    }

    /// <summary>
    /// Adds the specified number of stars to the player's star count
    /// </summary>
    /// <param name="amount">The amount of stars to add</param>
    public void AddStars(int amount)
    {
        starDisplay.AddStars(amount);
    }
}
