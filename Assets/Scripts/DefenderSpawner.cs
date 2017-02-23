using UnityEngine;

public class DefenderSpawner : MonoBehaviour
{
    public Camera myCamera;

    private GameObject parent;
    private StarDisplay starDisplay;

    /// <summary>
    /// Initialisation
    /// </summary>
    private void Start()
    {
        parent = GameObject.Find("Defenders");
        starDisplay = GameObject.FindObjectOfType<StarDisplay>();
        if (!parent)
        {
            parent = new GameObject("Defenders");
        }
    }

    /// <summary>
    /// Spawns a new defender of the selected type if it is affordable
    /// </summary>
    private void OnMouseDown()
    {
        Vector2 rawPos = CalculateWorldPointOfMouseClick();
        Vector2 roundedPos = SnapToGrid(rawPos);
        GameObject defender = Button.selectedDefender;

        int defenderCost = defender.GetComponent<Defender>().starCost;

        if (starDisplay.UseStars(defenderCost) == StarDisplay.Status.SUCCESS)
        {
            SpawnDefender(roundedPos, defender);
        }
        else
        {
            Debug.Log("Insufficient stars to spawn");
        }
    }

    /// <summary>
    /// Spawns a new specified defender at the specified position
    /// </summary>
    /// <param name="roundedPos">The position to spawn at</param>
    /// <param name="defender">The defender to spawn</param>
    private void SpawnDefender(Vector2 roundedPos, GameObject defender)
    {
        Quaternion zeroRot = Quaternion.identity;

        GameObject newDef = Instantiate(defender, roundedPos, zeroRot) as GameObject;

        newDef.transform.parent = parent.transform;
    }

    /// <summary>
    /// Returns a rounded world position
    /// </summary>
    /// <param name="rawWorldPos">The raw world position to round</param>
    /// <returns>Vector2</returns>
    private Vector2 SnapToGrid(Vector2 rawWorldPos)
    {
        // convert to int dont round
        float newX = Mathf.RoundToInt(rawWorldPos.x);
        float newY = Mathf.RoundToInt(rawWorldPos.y);

        return new Vector2(newX, newY);
    }

    /// <summary>
    /// Returns the World Point position of the mouse position at the Click event
    /// </summary>
    /// <returns>Vector2</returns>
    private Vector2 CalculateWorldPointOfMouseClick()
    {
        float mouseX = Input.mousePosition.x;
        float mouseY = Input.mousePosition.y;
        float distanceFromCamera = 10f;

        Vector3 weirdTriplet = new Vector3(mouseX, mouseY, distanceFromCamera);

        Vector2 worldPos = myCamera.ScreenToWorldPoint(weirdTriplet);

        return worldPos;
    }
}
