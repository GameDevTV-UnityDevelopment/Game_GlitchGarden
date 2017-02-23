using UnityEngine;
using UnityEngine.UI;

public class Button : MonoBehaviour
{
    public GameObject defenderPrefab;
    public static GameObject selectedDefender;

    private Button[] buttonArray;
    private Text costText;

    /// <summary>
    /// Initialisation
    /// </summary>
    void Start()
    {
        buttonArray = GameObject.FindObjectsOfType<Button>();
        costText = gameObject.GetComponentInChildren<Text>();

        if (!costText)
        {
            Debug.LogWarning(name = " has no cost text");
        }

        costText.text = defenderPrefab.GetComponent<Defender>().starCost.ToString();
    }

    /// <summary>
    /// Handles the MouseDown event for the defender buttons
    /// </summary>
    void OnMouseDown()
    {
        foreach (Button thisButton in buttonArray)
        {
            thisButton.GetComponent<SpriteRenderer>().color = Color.black;
        }

        gameObject.GetComponent<SpriteRenderer>().color = Color.white;

        selectedDefender = defenderPrefab;
    }
}
