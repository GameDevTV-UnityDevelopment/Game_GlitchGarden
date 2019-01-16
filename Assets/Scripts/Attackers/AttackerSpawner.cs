using UnityEngine;
using System.Collections;

public class AttackerSpawner : MonoBehaviour
{
    [SerializeField]
    private Attacker[] _attackerPrefabs = null;

    [SerializeField]
    private float _minSpawnDelay = EditorConfiguration.DEFAULT_ATTACKER_MIN_SPAWN_DELAY;

    [SerializeField]
    private float _maxSpawnDelay = EditorConfiguration.DEFAULT_ATTACKER_MAX_SPAWN_DELAY;

    private Lane _lane = null;
    private bool _spawn = true;
    private float _spawnDelay = 0f;


    private void OnDisable()
    {
        LevelTimer.OnComplete -= Stop;
        LevelController.OnLevelIncomplete -= Stop;
    }

    private void OnEnable()
    {
        LevelTimer.OnComplete += Stop;
        LevelController.OnLevelIncomplete += Stop;
    }

    private IEnumerator SpawnAttackers()
    {
        while (_spawn)
        {
            _spawnDelay = Random.Range(_minSpawnDelay, _maxSpawnDelay);

            yield return new WaitForSeconds(_spawnDelay);

            if (_spawn)
            {
                SpawnAttacker();
            }
        }
    }

    private void SpawnAttacker()
    {
        if (_attackerPrefabs.Length > 0)
        {
            int attackerIndex = Random.Range(0, _attackerPrefabs.Length);

            Attacker attacker = Instantiate(_attackerPrefabs[attackerIndex], transform.position, transform.rotation);

            if (_lane)
            {
                attacker.Lane = _lane;
                attacker.transform.parent = _lane.Attackers.transform;
            }
        }
    }

    private void Start()
    {
        _lane = GetComponentInParent<Lane>();
        StartCoroutine(SpawnAttackers());
    }

    private void Stop()
    {
        _spawn = false;
    }
}