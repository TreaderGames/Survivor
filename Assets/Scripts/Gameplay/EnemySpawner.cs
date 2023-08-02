using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyBase enemyTemplate;
    [SerializeField] RectTransform ground;
    [SerializeField] int spawnMovingCount = 5;

    List<EnemyBase> movingEnemies = new List<EnemyBase>();


    #region Public

    public List<EnemyBase> SpawnEnemies()
    {
        EnemyBase currentEnemy;
        Vector3 boundsMin = new Vector3(ground.rect.xMin, ground.rect.yMin, 0);
        Vector3 boundsMax = new Vector3(ground.rect.xMax, ground.rect.yMax, 0);
        Vector3 randomPos = new Vector3();

        for (int i = 0; i < spawnMovingCount; i++)
        {
            currentEnemy = Instantiate(enemyTemplate, transform);
            currentEnemy.gameObject.SetActive(true);
            randomPos.x = Random.Range(boundsMin.x, boundsMax.x);
            randomPos.y = Random.Range(boundsMin.y, boundsMax.y);

            currentEnemy.transform.localPosition = randomPos;
            movingEnemies.Add(currentEnemy);
        }

        return movingEnemies;
    }
    #endregion
}
