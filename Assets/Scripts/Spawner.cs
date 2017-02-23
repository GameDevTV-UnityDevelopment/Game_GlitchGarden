using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject[] attackerPrefabArray;

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    void Update()
    {
        foreach (GameObject thisAttacker in attackerPrefabArray)
        {
            if (isTimeToSpawn(thisAttacker))
            {
                Spawn(thisAttacker);
            }
        }
    }

    /// <summary>
    /// Determins if it is time to spawn another attacker
    /// </summary>
    /// <param name="attackerGameObject">The attacking GameObject</param>
    /// <returns>Bool</returns>
    private bool isTimeToSpawn(GameObject attackerGameObject)
    {
        Attacker attacker = attackerGameObject.GetComponent<Attacker>();

        float meanSpawnDelay = attacker.seenEverySeconds;
        float spawnsPerSecond = 1 / meanSpawnDelay;

        if (Time.deltaTime > meanSpawnDelay)
        {
            Debug.LogWarning("Spawn rate capped by frame rate");
        }

        float threshold = spawnsPerSecond * Time.deltaTime / 5;

        return (Random.value < threshold);
    }

    /// <summary>
    /// Spawns the specified game object at the spawn point
    /// </summary>
    /// <param name="myGameObject">The GameObject to spawn</param>
    private void Spawn(GameObject myGameObject)
    {
        GameObject myAttacker = Instantiate(myGameObject) as GameObject;

        myAttacker.transform.parent = gameObject.transform;
        myAttacker.transform.position = gameObject.transform.position;
    }
}
