using UnityEngine;
using UnityEngine.UI;

public class FadeIn : MonoBehaviour
{
    public float fadeInTime;

    private Image fadePanel;
    private Color currentColor = Color.black;

    /// <summary>
    /// Initialise
    /// </summary>
    void Start()
    {
        fadePanel = gameObject.GetComponent<Image>();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        if (Time.timeSinceLevelLoad < fadeInTime)
        {
            // fade in
            float alphaChange = Time.deltaTime / fadeInTime;

            currentColor.a -= alphaChange;
            fadePanel.color = currentColor;
        }
        else
        {
            gameObject.SetActive(false);
        }
    }
}
