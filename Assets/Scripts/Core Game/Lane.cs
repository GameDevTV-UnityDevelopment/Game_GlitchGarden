using UnityEngine;

public class Lane : MonoBehaviour
{
    private GameObject _attackers = null;
    private GameObject _defenders = null;
    private GameObject _projectiles = null;
    private GameObject _deathFX = null;


    public GameObject Attackers
    {
        get { return _attackers; }
    }

    public GameObject Defenders
    {
        get { return _defenders; }
    }

    public GameObject Projectiles
    {
        get { return _projectiles; }
    }

    public GameObject DeathFX
    {
        get { return _deathFX; }
    }


    private void Awake()
    {
        _attackers = new GameObject(GameConfiguration.GAMEOBJECT_PARENT_ATTACKERS);
        _defenders = new GameObject(GameConfiguration.GAMEOBJECT_PARENT_DEFENDERS);
        _projectiles = new GameObject(GameConfiguration.GAMEOBJECT_PARENT_PROJECTILES);
        _deathFX = new GameObject(GameConfiguration.GAMEOBJECT_PARENT_DEATHFX);

        _attackers.transform.parent = gameObject.transform;
        _defenders.transform.parent = gameObject.transform;
        _projectiles.transform.parent = gameObject.transform;
        _deathFX.transform.parent = gameObject.transform;
    }
}