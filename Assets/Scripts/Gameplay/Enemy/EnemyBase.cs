using System;
using UnityEngine;

public class EnemyBase : MonoBehaviour
{
    public bool isTouchingPlayer;
    [SerializeField] int health = 3;

    Action<EnemyBase> enemyDestroyed;

    int currentHealth;

    #region Untiy

    private void OnEnable()
    {
        currentHealth = health;
    }

    private void OnDisable()
    {
        enemyDestroyed = null;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.PLAYER_TAG))
        {
            Debug.Log("Touching player");
            isTouchingPlayer = true;
        }
        if (collision.CompareTag(GameTags.BULLT_TAG) && collision.GetComponent<Bullet>().pBulletTarget.Equals(Bullet.BulletTarget.Enemy))
        {
            HitWithBullet();
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag(GameTags.PLAYER_TAG))
        {
            Debug.Log("Player moved away");
            isTouchingPlayer = false;
        }
    }
    #endregion

    #region Private
    private void HitWithBullet()
    {
        currentHealth--;
        if(currentHealth == 0)
        {
            enemyDestroyed?.Invoke(this);
        }
    }
    #endregion

    #region Public
    public void AddEnemyDefeatedListener(Action<EnemyBase> action)
    {
        enemyDestroyed += action;
    }

    public void RemoveEnemyDefeatedListener(Action<EnemyBase> action)
    {
        enemyDestroyed -= action;
    }

    public void Respawn(Vector3 position)
    {
        currentHealth = health;
        transform.localPosition = position;
    }
    #endregion
}
