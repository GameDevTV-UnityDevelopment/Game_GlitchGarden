using UnityEngine;

public class Lanes : MonoBehaviour
{
    private Lane[] _lanes = null;


    public Lane FindLaneByWorldPoint(Vector3 worldPoint)
    {
        Lane result = null;

        foreach (Lane lane in _lanes)
        {
            if (lane.transform.position.y == worldPoint.y)
            {
                result = lane;
                break;
            }
        }

        return result;
    }

    private void Awake()
    {
        _lanes = GetComponentsInChildren<Lane>();
    }
}