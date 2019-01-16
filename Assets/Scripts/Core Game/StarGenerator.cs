using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    [SerializeField]
    private int _production = EditorConfiguration.DEFAULT_STAR_PRODUCTION;

    private bool _running = false;
    private Stars _stars = null;


    public void Generate()
    {
        if (_running)
        {
            _stars.Increase(_production);
        }
    }

    private void Awake()
    {
        _running = true;
        _stars = FindObjectOfType<Stars>();
    }

    private void OnDisable()
    {
        LevelController.OnLevelComplete -= Stop;
        LevelController.OnLevelIncomplete -= Stop;
    }

    private void OnEnable()
    {
        LevelController.OnLevelComplete += Stop;
        LevelController.OnLevelIncomplete += Stop;
    }

    private void Stop()
    {
        _running = false;
    }
}