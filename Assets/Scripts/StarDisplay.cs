using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class StarDisplay : MonoBehaviour
{
    public enum Status { SUCCESS, FAILURE };

    private Text starText;
    private int stars = 100;

    /// <summary>
    /// Initialisation
    /// </summary>
    private void Start()
    {
        starText = gameObject.GetComponent<Text>();
        UpdateDisplay();
    }

    /// <summary>
    /// Adds stars to the player's star count
    /// </summary>
    /// <param name="amount">The amount of stars to add</param>
    public void AddStars(int amount)
    {
        stars += amount;
        UpdateDisplay();
    }

    /// <summary>
    /// Reduces stars from the player's star count
    /// </summary>
    /// <param name="amount">The amount of star to remove</param>
    public Status UseStars(int amount)
    {
        if (stars >= amount)
        {
            stars -= amount;
            UpdateDisplay();

            return Status.SUCCESS;
        }
        return Status.FAILURE;
    }

    /// <summary>
    /// Updates the number of stars displayed
    /// </summary>
    private void UpdateDisplay()
    {
        starText.text = stars.ToString();
    }
}
