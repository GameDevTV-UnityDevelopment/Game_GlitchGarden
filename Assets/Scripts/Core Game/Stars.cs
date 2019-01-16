using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Stars : MonoBehaviour
{
    [SerializeField]
    private int _count = EditorConfiguration.DEFAULT_PLAYER_STARS;

    private Text _starDisplay = null;


    public int Count
    {
        get { return _count; }
    }


    public void Decrease(int value)
    {
        _count -= value;

        UpdateDisplay();
    }

    public void Increase(int value)
    {
        _count += value;

        UpdateDisplay();
    }

    private void Awake()
    {
        _starDisplay = GetComponent<Text>();

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _starDisplay.text = _count.ToString();
    }
}