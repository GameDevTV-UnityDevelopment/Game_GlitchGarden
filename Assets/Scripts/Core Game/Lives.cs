using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Text))]
public class Lives : MonoBehaviour
{
    [SerializeField]
    private int _count = EditorConfiguration.DEFAULT_PLAYER_LIVES;

    private Text _livesDisplay = null;


    public delegate void Death();
    public static event Death OnDeath;


    public int Count
    {
        get { return _count; }
    }


    public void Decrease(int value)
    {
        _count -= value;

        UpdateDisplay();

        if (_count == 0)
        {
            if (OnDeath != null)
            {
                OnDeath();
            }
        }
    }

    public void Increase(int value)
    {
        _count += value;

        UpdateDisplay();
    }

    private void Awake()
    {
        _livesDisplay = GetComponent<Text>();

        UpdateDisplay();
    }

    private void UpdateDisplay()
    {
        _livesDisplay.text = _count.ToString();
    }
}