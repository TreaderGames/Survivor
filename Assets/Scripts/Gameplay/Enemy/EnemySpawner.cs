using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyBase enemyTemplate;
    [SerializeField] EnemyBase enemyStaticTemplate;
    [SerializeField] UIWorldInfo worldInfo;
    [SerializeField] int spawnMovingCount = 5;
    [SerializeField] int spawnStaticCount = 3;

    List<EnemyBase> movingEnemies = new List<EnemyBase>();

    #region Public

    public List<EnemyBase> SpawnMovingEnemies()
    {
        EnemyBase currentEnemy;
        Vector3 randomPos;

        for (int i = 0; i < spawnMovingCount; i++)
        {
            currentEnemy = Instantiate(enemyTemplate, transform);
            currentEnemy.gameObject.SetActive(true);
            randomPos = Utilities.GetRandom2DPosWithingBounds(worldInfo.pBoundsMin, worldInfo.pBoundsMax);

            currentEnemy.transform.localPosition = randomPos;
            movingEnemies.Add(currentEnemy);
        }

        return movingEnemies;
    }

    public void SpawnStaticEnemies()
    {
        EnemyBase currentEnemy;
        Vector3 randomPos;

        for (int i = 0; i < spawnStaticCount; i++)
        {
            currentEnemy = Instantiate(enemyStaticTemplate, transform);
            currentEnemy.gameObject.SetActive(true);
            randomPos = Utilities.GetRandom2DPosWithingBounds(worldInfo.pBoundsMin, worldInfo.pBoundsMax);

            currentEnemy.transform.localPosition = randomPos;
        }
    }

    #endregion
}
