using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    [SerializeField] EnemySpawner enemySpawner;
    [SerializeField] EnemyMovement enemyMovement;
    List<EnemyBase> movingEnemies = new List<EnemyBase>();

    #region Unity
    // Start is called before the first frame update
    void Start()
    {
        movingEnemies = enemySpawner.SpawnEnemies();
        enemyMovement.StartMoving(movingEnemies);
    }
    #endregion
}
