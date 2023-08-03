using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour, IReset
{
    [SerializeField] EnemyBase enemyTemplate;
    [SerializeField] EnemyBase enemyStaticTemplate;
    [SerializeField] UIWorldInfo worldInfo;
    [SerializeField] int spawnMovingCount = 5;
    [SerializeField] int spawnStaticCount = 3;

    List<EnemyBase> movingEnemies = new List<EnemyBase>();
    List<EnemyBase> staticEnemies = new List<EnemyBase>();

    #region Unity
    private void Start()
    {
        ResetGame.Instance.AddResetableListener(this);
    }
    #endregion

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
            currentEnemy.AddEnemyDefeatedListener(HandleEnemyDefeated);
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

            currentEnemy.AddEnemyDefeatedListener(HandleEnemyDefeated);
            currentEnemy.transform.localPosition = randomPos;
            staticEnemies.Add(currentEnemy);
        }
    }

    public void DoReset()
    {
        for (int i = 0; i < movingEnemies.Count; i++)
        {
            movingEnemies[i].Respawn(Utilities.GetRandom2DPosWithingBounds(worldInfo.pBoundsMin, worldInfo.pBoundsMax));
        }

        for (int i = 0; i < staticEnemies.Count; i++)
        {
            staticEnemies[i].Respawn(Utilities.GetRandom2DPosWithingBounds(worldInfo.pBoundsMin, worldInfo.pBoundsMax));
        }
    }

    #endregion

    #region Callback
    private void HandleEnemyDefeated(EnemyBase enemyBase)
    {
        CoinSpawner.Instance.SpawnCoin(enemyBase.transform.localPosition);
        enemyBase.Respawn(Utilities.GetRandom2DPosWithingBounds(worldInfo.pBoundsMin, worldInfo.pBoundsMax));
    }
    #endregion
}
