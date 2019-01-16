using UnityEngine;
using System;
using System.Collections.Generic;

public class DefenderSpawner : MonoBehaviour
{
    private List<Vector2> _spawnedDefenders = new List<Vector2>();
    private Lanes _lanes = null;
    private Defender _selectedDefender = null;
    private Vector2 _selectedSpawnPosition;
    private bool _spawn;
    private Stars _stars = null;


    public Defender SelectedDefender
    {
        set { _selectedDefender = value; }
    }


    private void Awake()
    {
        _spawn = true;
        _lanes = FindObjectOfType<Lanes>();
        _stars = FindObjectOfType<Stars>();
    }

    private void BuyDefender()
    {
        if (_stars.Count >= _selectedDefender.Cost)
        {
            _stars.Decrease(_selectedDefender.Cost);
            SpawnDefender();
        }
    }

    private Lane GetLaneByWorldPoint(Vector3 worldPoint)
    {
        return _lanes.FindLaneByWorldPoint(worldPoint);
    }

    private Vector2 GetSpawnPosition()
    {
        Vector2 clickPositionInWorldUnits = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        clickPositionInWorldUnits.x = Mathf.RoundToInt(clickPositionInWorldUnits.x);
        clickPositionInWorldUnits.y = Mathf.RoundToInt(clickPositionInWorldUnits.y);

        return clickPositionInWorldUnits;
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

    private void OnMouseDown()
    {
        if (_spawn)
        {
            _selectedSpawnPosition = GetSpawnPosition();

            if (!_spawnedDefenders.Contains(_selectedSpawnPosition))
            {
                BuyDefender();
            }
        }
    }

    private void RemoveSpawnedDefender(Defender defender)
    {
        defender.OnDeath -= RemoveSpawnedDefender;

        _spawnedDefenders.Remove(defender.transform.position);
    }

    private void SpawnDefender()
    {
        Lane lane = GetLaneByWorldPoint(_selectedSpawnPosition);
        Transform parent = lane.Defenders.transform;

        Defender defender = Instantiate(_selectedDefender, _selectedSpawnPosition, Quaternion.identity, parent);

        defender.Lane = lane;

        defender.OnDeath += RemoveSpawnedDefender;

        _spawnedDefenders.Add(defender.transform.position);
    }

    private void Stop()
    {
        _spawn = false;
    }
}