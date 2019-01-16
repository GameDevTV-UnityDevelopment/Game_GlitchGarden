using UnityEngine;

public class DefenderButtons : MonoBehaviour
{
    [SerializeField]
    private Color _deselectedColor = new Color32
                                        (
                                            EditorConfiguration.DEFAULT_DESELECTED_BUTTON_COLOUR_R,
                                            EditorConfiguration.DEFAULT_DESELECTED_BUTTON_COLOUR_G,
                                            EditorConfiguration.DEFAULT_DESELECTED_BUTTON_COLOUR_B,
                                            EditorConfiguration.DEFAULT_DESELECTED_BUTTON_COLOUR_A
                                        );

    [SerializeField]
    private Color _selectedColor = new Color32
                                        (
                                            EditorConfiguration.DEFAULT_SELECTED_BUTTON_COLOUR_R,
                                            EditorConfiguration.DEFAULT_SELECTED_BUTTON_COLOUR_G,
                                            EditorConfiguration.DEFAULT_SELECTED_BUTTON_COLOUR_B,
                                            EditorConfiguration.DEFAULT_SELECTED_BUTTON_COLOUR_A
                                        );

    private DefenderButton[] _defenderButtons = null;


    private void Awake()
    {
        _defenderButtons = GetComponentsInChildren<DefenderButton>();

        SetSelectedColor();
    }

    private void DisableButtons()
    {
        foreach (DefenderButton button in _defenderButtons)
        {
            button.GetComponentInChildren<SpriteRenderer>().color = _deselectedColor;
        }
    }

    private void OnDisable()
    {
        DefenderButton.OnSelection -= DisableButtons;
    }

    private void OnEnable()
    {
        DefenderButton.OnSelection += DisableButtons;
    }

    private void SetInitialSelection()
    {
        if (_defenderButtons.Length > 0)
        {
            _defenderButtons[0].Selected();
        }
    }

    private void SetSelectedColor()
    {
        foreach (DefenderButton button in _defenderButtons)
        {
            button.SelectedColor = _selectedColor;
        }
    }

    private void Start()
    {
        SetInitialSelection();
    }
}