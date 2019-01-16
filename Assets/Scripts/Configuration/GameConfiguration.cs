using UnityEngine;

public class GameConfiguration : MonoBehaviour
{
    // scenes
    public const string START_SCREEN = "Start Screen";
    public const string OPTIONS_SCREEN = "Options Screen";
    public const string LOSE_SCREEN = "Lose Screen";
    public const string FIRST_LEVEL = "Level 1";
    public const string LEVEL_COMPLETE = "Level Complete";
    public const string LEVEL_INCOMPLETE = "Level Incomplete";
    public const string GAME_WON = "Game Won";


    // audio
    public const float MIN_VOLUME = 0f;
    public const float MAX_VOLUME = 1f;
    public const float DEFAULT_MASTER_VOLUME = 0.8f;


    // gameobject parents
    public const string GAMEOBJECT_PARENT_ATTACKERS = "Attackers";
    public const string GAMEOBJECT_PARENT_DEFENDERS = "Defenders";
    public const string GAMEOBJECT_PARENT_PROJECTILES = "Projectiles";
    public const string GAMEOBJECT_PARENT_DEATHFX = "Death Effects";


    // animation parameters
    public const string ATTACKER_ATTACKING_PARAMETER = "IsAttacking";
    public const string DEFENDER_ATTACKING_PARAMETER = "IsAttacking";
    public const string DEFENDER_BLOCKING_PARAMETER = "IsBlocking";


    // playerprefs keys
    public const string PLAYERPREFS_KEY_MASTER_VOLUME = "master volume";
    public const string PLAYERPREFS_KEY_DIFFICULTY = "difficulty";


    // gameplay
    public const int BASE_ATTACK_DAMAGE = 1;

    public const float MIN_DIFFICULTY = 1f;
    public const float MAX_DIFFICULTY = 3f;
    public const float DEFAULT_DIFFICULTY_LEVEL = 1f;
}