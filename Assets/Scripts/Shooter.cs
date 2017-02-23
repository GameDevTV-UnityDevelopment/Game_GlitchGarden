using UnityEngine;

public class Shooter : MonoBehaviour
{
    public GameObject projectile, gun;

    private GameObject projectileParent;
    private Animator animator;
    private Spawner myLaneSpawner;

    /// <summary>
    /// Initialisation
    /// </summary>
    private void Start()
    {
        animator = GameObject.FindObjectOfType<Animator>();

        // creates a parent if necessary
        projectileParent = GameObject.Find("Projectiles");

        if (!projectileParent)
        {
            projectileParent = new GameObject("Projectiles");
        }

        SetMyLaneSpawner();
    }

    /// <summary>
    /// Update is called once per frame
    /// </summary>
    private void Update()
    {
        if (IsAttackerAheadInLane())
        {
            animator.SetBool("isAttacking", true);
        }
        else
        {
            animator.SetBool("isAttacking", false);
        }
    }

    /// <summary>
    /// Indicates whether there is an attacker in front of the defender
    /// </summary>
    /// <returns>Bool</returns>
    private bool IsAttackerAheadInLane()
    {
        // Exit if no attackers in lane
        if (myLaneSpawner.transform.childCount <= 0)
        {
            return false;
        }

        // If there are attackers, are they ahead?
        foreach (Transform attacker in myLaneSpawner.transform)
        {
            if (attacker.transform.position.x > transform.position.x)
            {
                return true;
            }
        }

        // Attackers in lane, but behind us
        return false;
    }

    /// <summary>
    /// Sets the attacking spawner for this lane
    /// </summary>
    private void SetMyLaneSpawner()
    {
        Spawner[] spawnerArray = GameObject.FindObjectsOfType<Spawner>();

        foreach (Spawner spawner in spawnerArray)
        {
            if (spawner.transform.position.y == transform.position.y)
            {
                myLaneSpawner = spawner;
                return;
            }
        }

        Debug.LogError(name + " can't find spawner in lane");
    }

    /// <summary>
    /// Fires a projectile at an attacker
    /// </summary>
    private void FireGun()
    {
        GameObject newProjectile = Instantiate(projectile) as GameObject;

        newProjectile.transform.parent = projectileParent.transform;

        newProjectile.transform.position = gun.transform.position;
    }
}
