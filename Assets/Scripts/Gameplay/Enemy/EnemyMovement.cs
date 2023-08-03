using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour, IReset
{
    [SerializeField] float speed = 1;
    [SerializeField] RectTransform player;
    [SerializeField] float delayedStart = 2;

    List<EnemyBase> movingEnemies = new List<EnemyBase>();

    float currentDelta = 0;

    #region Unity
    private void LateUpdate()
    {
        if(movingEnemies.Count > 0 && currentDelta > delayedStart)
        {
            DoMoveEnemies();
        }
        else
        {
            currentDelta += Time.deltaTime;
        }
    }
    #endregion

    #region Public

    public void StartMoving(List<EnemyBase> enemies)
    {
        movingEnemies = enemies;
    }

    #endregion

    #region Private
    private void DoMoveEnemies()
    {
        float deltaTime = Time.deltaTime;
        Vector3 playerPos = player.position;
        Vector3 enemyPos;
        foreach (EnemyBase enemy in movingEnemies)
        {
            if(!enemy.isTouchingPlayer)
            {
                enemyPos = enemy.transform.position;
                enemy.transform.position = Vector3.MoveTowards(enemyPos, playerPos, deltaTime * speed);
            }
        }
    }

    public void DoReset()
    {
        currentDelta = 0;
    }
    #endregion
}
