using UnityEngine;

[RequireComponent(typeof(Defender))]
public class Shooter : MonoBehaviour
{
    [SerializeField]
    private GameObject _projectilePrefab = null;

    [SerializeField]
    private Transform _projectileSpawn = null;

    private Defender _defender = null;


    public void Fire()
    {
        GameObject projectile = Instantiate(_projectilePrefab, _projectileSpawn.position, _projectileSpawn.rotation);

        projectile.transform.parent = _defender.Lane.Projectiles.transform;
    }

    private void Awake()
    {
        _defender = GetComponent<Defender>();
    }
}