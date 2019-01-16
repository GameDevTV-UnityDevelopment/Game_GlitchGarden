using UnityEngine;
using UnityEngine.UI;

public class DefenderButton : MonoBehaviour
{
    [SerializeField]
    private Defender _defenderPrefab = null;

    private Text _cost;
    private DefenderSpawner _defenderSpawner = null;
    private Color _selectedColor;


    public delegate void Selection();
    public static event Selection OnSelection;


    public Color SelectedColor
    {
        set { _selectedColor = value; }
    }


    public void Selected()
    {
        if (OnSelection != null)
        {
            OnSelection();
        }

        _defenderSpawner.SelectedDefender = _defenderPrefab;
        GetComponentInChildren<SpriteRenderer>().color = _selectedColor;
    }

    private void Awake()
    {
        _cost = GetComponentInChildren<Text>();
        _defenderSpawner = FindObjectOfType<DefenderSpawner>();
    }

    private void OnMouseDown()
    {
        Selected();
    }

    private void Start()
    {
        _cost.text = _defenderPrefab.Cost.ToString();
    }
}