using System;
using UnityEngine;

public class PlayerHealthController : Singleton<PlayerHealthController>
{
    [SerializeField] int playerHealth = 10;

    private Action<int> callbackHealthUpdated;
    private int currentHealth;

    public int pPlayerHealth { get => playerHealth; }

    //public int pCurrentHealth { get; private set; }

    #region Unity
    private void Awake()
    {
        currentHealth = playerHealth;
    }
    #endregion

    #region Public
    public void HitByBullet()
    {
        currentHealth--;
        Debug.Log("Player health: " + currentHealth);
        callbackHealthUpdated?.Invoke(currentHealth);
        if(currentHealth == 0)
        {
            HandlePlayerDeath();
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
    #endregion
}
