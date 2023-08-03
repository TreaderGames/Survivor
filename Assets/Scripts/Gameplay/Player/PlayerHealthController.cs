using System;
using UnityEngine;

public class PlayerHealthController : Singleton<PlayerHealthController>
{
    [SerializeField] int playerHealth = 10;
    [SerializeField] float meleeHitDelay = 1;

    private Action<int> callbackHealthUpdated;
    private int currentHealth;
    private int enemyContactCount;
    private float currentDelta = 0;

    public int pPlayerHealth { get => playerHealth; }

    //public int pCurrentHealth { get; private set; }

    #region Unity
    private void Awake()
    {
        currentHealth = playerHealth;
    }

    private void Update()
    {
        if(currentDelta >= meleeHitDelay)
        {
            UpdateEnemyContactHealth();
            currentDelta = 0;
        }
        else
        {
            currentDelta += Time.deltaTime;
        }
    }
    #endregion

    #region Public
    public void HitByBullet()
    {
        currentHealth--; 
        currentHealth = Mathf.Max(currentHealth, 0);
        currentDelta = 0;
        Debug.Log("Player health: " + currentHealth);
        callbackHealthUpdated?.Invoke(currentHealth);
        if (currentHealth == 0)
        {
            HandlePlayerDeath();
        }
    }

    public void UpdateEnemyContract(bool enter)
    {
        if(enter)
        {
            Debug.Log("cp3");
            enemyContactCount++;
            //UpdateEnemyContactHealth();
        }
        else
        {
            if (enemyContactCount > 0)
            {
                enemyContactCount--;
            }
        }
    }

    public void AddListener(Action<int> callback)
    {
        callbackHealthUpdated += callback;
    }

    public void RemoveListener(Action<int> callback)
    {
        callbackHealthUpdated -= callback;
    }
    #endregion

    #region Private
    private void HandlePlayerDeath()
    {
        currentHealth = playerHealth;
    }

    private void UpdateEnemyContactHealth()
    {
        Debug.LogError("Enemy Contact Count: " + enemyContactCount);
        currentHealth = currentHealth - enemyContactCount;
        currentHealth = Mathf.Max(currentHealth, 0);
        callbackHealthUpdated?.Invoke(currentHealth);
    }    
    #endregion
}
