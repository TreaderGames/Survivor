using System.Collections;
using UnityEngine.UI;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Transform enemyTemplate;
    [SerializeField] RectTransform ground;
    [SerializeField] int spawnMovingCount = 5;

    #region Unity
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    #endregion

    #region Private

    private void SpawnEnemies()
    {
        Transform currentEnemy;
        Vector3 boundsMin = new Vector3(ground.rect.xMin, ground.rect.yMin, 0);
        Vector3 boundsMax = new Vector3(ground.rect.xMax, ground.rect.yMax, 0);
        Vector3 randomPos = new Vector3();

        for (int i = 0; i < spawnMovingCount; i++)
        {
            currentEnemy = Instantiate(enemyTemplate, transform);
            currentEnemy.gameObject.SetActive(true);
            randomPos.x = Random.Range(boundsMin.x, boundsMax.x);
            randomPos.y = Random.Range(boundsMin.y, boundsMax.y);

            currentEnemy.localPosition = randomPos;
        }
    }

    #endregion
}
