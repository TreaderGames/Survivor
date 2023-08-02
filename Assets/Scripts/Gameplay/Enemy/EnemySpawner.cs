using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] EnemyBase enemyTemplate;
    [SerializeField] EnemyBase enemyStaticTemplate;
    [SerializeField] RectTransform ground;
    [SerializeField] int spawnMovingCount = 5;
    [SerializeField] int spawnStaticCount = 3;

    List<EnemyBase> movingEnemies = new List<EnemyBase>();
    Vector3 boundsMin;
    Vector3 boundsMax;

    #region Unity

    private void Awake()
    {
        boundsMin = new Vector3(ground.rect.xMin, ground.rect.yMin, 0);
        boundsMax = new Vector3(ground.rect.xMax, ground.rect.yMax, 0);
    }

    #endregion

    #region Public

    public List<EnemyBase> SpawnMovingEnemies()
    {
        EnemyBase currentEnemy;
        Vector3 randomPos = new Vector3();

        for (int i = 0; i < spawnMovingCount; i++)
        {
            currentEnemy = Instantiate(enemyTemplate, transform);
            currentEnemy.gameObject.SetActive(true);
            randomPos = Utilities.GetRandom2DPosWithingBounds(boundsMin, boundsMax);

            currentEnemy.transform.localPosition = randomPos;
            movingEnemies.Add(currentEnemy);
        }

        return movingEnemies;
    }

    public void SpawnStaticEnemies()
    {
        EnemyBase currentEnemy;
        Vector3 randomPos = new Vector3();

        for (int i = 0; i < spawnStaticCount; i++)
        {
            currentEnemy = Instantiate(enemyStaticTemplate, transform);
            currentEnemy.gameObject.SetActive(true);
            randomPos = Utilities.GetRandom2DPosWithingBounds(boundsMin, boundsMax);

            currentEnemy.transform.localPosition = randomPos;
        }
    }

    #endregion
}
