using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float speed = 1;
    [SerializeField] RectTransform player;

    List<EnemyBase> movingEnemies = new List<EnemyBase>();

    #region Unity
    private void LateUpdate()
    {
        if(movingEnemies.Count > 0)
        {
            DoMoveEnemies();
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
    #endregion
}
